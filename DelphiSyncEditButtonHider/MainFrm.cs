using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DelphiFixer {
    public partial class MainFrm : Form {

        public delegate bool Win32Callback(IntPtr hwnd, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int FindWindowEx(int hwndParent, int hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll")]
        static extern bool ShowWindowAsync(int hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        static extern int GetForegroundWindow();

        private const int SW_HIDE = 0;

        public MainFrm() {
            InitializeComponent();
        }

        private void DoHideSyncButton() {
            var hwnd = FindWindow("TAppBuilder", null);

            if (hwnd == 0) {
                // Delphi not open.
                return;
            }
            var activeWindow = GetForegroundWindow();
            if (hwnd != activeWindow) {
                // Delphi isn't active, no point wasting resources.
                return;
            }

            var level1 = FindWindowEx(hwnd, 0, "TEditorDockPanel", null);
            var level2 = FindWindowEx(level1, 0, "TEditWindow", null);
            var level3 = FindWindowEx(level2, 0, "TPanel", null);
            var level4 = FindWindowEx(level3, 0, "TPanel", null);

            var level5Children = GetAllChildrenHandles(level4, "TPanel");
            var level5 = level5Children[1];

            // Second panel in the child5List holds the 6th child.
            var level6 = FindWindowEx(level5, 0, "TPanel", null);

            var level7Children = GetAllChildrenHandles(level6, "TPanel");
            if (level7Children.Count < 1) {
                richTextBox1.AppendText("Failed to find level 7 child (level 7 children list was 0).\r\n");
                return;
            }
            var level7 = level7Children[0];

            // Second panel in the child7List holds the 8th child.
            var level8 = FindWindowEx(level7, 0, "TPanel", null);

            var level9Children = GetAllChildrenHandles(level8, null);
            if (level9Children.Count < 1) {
                richTextBox1.AppendText("Failed to find level 9 child (level 9 children list was 0).\r\n");
                return;
            }
            var level9 = level9Children[0];
            var level10 = FindWindowEx(level9, 0, "TSyncButton", null);
            ShowWindowAsync(level10, SW_HIDE);
        }

        private List<int> GetAllChildrenHandles(int hParent, string className) {
            List<int> list = new List<int>();
            int prevChild = 0;
            int currChild = 0;

            do {
                currChild = FindWindowEx(hParent, prevChild, className, null);
                if (currChild == 0)
                    break;
                list.Add(currChild);
                prevChild = currChild;;
            }
            while (true);

            return list;
        }

        private void MainFrm_Load(object sender, EventArgs e) {
            IntervalTextBx.Text = Properties.Settings.Default.interval.ToString();
        }

        private void FixerEnabledCheckBx_CheckedChanged(object sender, EventArgs e) {
            if (FixerEnabledCheckBx.Checked) {
                int intInterval;
                if (int.TryParse(IntervalTextBx.Text, out intInterval)) {
                    HiderTmr.Interval = intInterval;
                } else {
                    MessageBox.Show("Could not parse the interval textbox. It needs to contain a whole number in milliseconds.");
                    FixerEnabledCheckBx.Checked = false;
                    return;
                }                
            }
            HiderTmr.Enabled = FixerEnabledCheckBx.Checked;
        }

        private void SaveIntervalBtn_Click(object sender, EventArgs e) {
            int intInterval;
            if (int.TryParse(IntervalTextBx.Text, out intInterval)) {
                Properties.Settings.Default.interval = intInterval;
                Properties.Settings.Default.Save();
                MessageBox.Show("Saved!");
            } else {
                MessageBox.Show("Could not parse the interval textbox. It needs to contain a whole number in milliseconds.");
                return;
            }
        }

        private void HiderTmr_Tick(object sender, EventArgs e) {
            HiderTmr.Enabled = false;
            DoHideSyncButton();
            if (FixerEnabledCheckBx.Checked) {
                HiderTmr.Enabled = true;
            }
        }
    }
}
