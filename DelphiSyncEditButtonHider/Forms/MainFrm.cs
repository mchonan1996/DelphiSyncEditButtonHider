using System;
using System.Windows.Forms;
using Microsoft.Win32;

using DelphiSyncEditButtonHider.Classes;

namespace DelphiSyncEditButtonHider.Forms {
    public partial class MainFrm : Form {
        
        private const string AppName = "DelphiSEButtonHider";

        private bool _AppLoading = false;

        public MainFrm() {
            InitializeComponent();
        }
                
        private void SetStartup() {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);                
            if (RunOnSystemStartupCheckBx.Checked) {
                rk.SetValue(AppName, Application.ExecutablePath);
            } else {
                rk.DeleteValue(AppName, false);
            }
        } 
        
        private bool GetStartupIsEnabled() {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            return (rk.GetValue(AppName, null) != null);
        }

        private void MainFrm_Load(object sender, EventArgs e) {
            _AppLoading = true;
            try {
                IntervalTextBx.Text = Properties.Settings.Default.Interval.ToString();
                EnableHiderOnStartupCheckBx.Checked = Properties.Settings.Default.EnableHiderOnStartup;
                MinimizeToTrayCheckBx.Checked = Properties.Settings.Default.MinimizeToTray;
                RunOnSystemStartupCheckBx.Checked = GetStartupIsEnabled();

                if ((RunOnSystemStartupCheckBx.Checked) && (MinimizeToTrayCheckBx.Checked)) {
                    this.WindowState = FormWindowState.Minimized;
                    ShowInTaskbar = false;
                }
                if (EnableHiderOnStartupCheckBx.Checked) {
                    FixerEnabledCheckBx.Checked = true;
                }
            }
            finally {
                _AppLoading = false;
            }            
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
                Properties.Settings.Default.Interval = intInterval;
                Properties.Settings.Default.Save();
                MessageBox.Show("Saved!");
            } else {
                MessageBox.Show("Could not parse the interval textbox. It needs to contain a whole number in milliseconds.");
                return;
            }
        }

        private void HiderTmr_Tick(object sender, EventArgs e) {
            HiderTmr.Enabled = false;
            new DelphiHacker().DoHideSyncButton();
            if (FixerEnabledCheckBx.Checked) {
                HiderTmr.Enabled = true;
            }
        }

        private void EnableHiderOnStartupCheckBx_CheckedChanged(object sender, EventArgs e) {
            if (!_AppLoading) {
                Properties.Settings.Default.EnableHiderOnStartup = EnableHiderOnStartupCheckBx.Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void RunOnSystemStartupCheckBx_CheckedChanged(object sender, EventArgs e) {
            if (!_AppLoading) {
                SetStartup();
            }
        }

        private void MinimizeToTrayCheckBx_CheckedChanged(object sender, EventArgs e) {
            if (!_AppLoading) {
                if (MinimizeToTrayCheckBx.Checked) {
                    Properties.Settings.Default.ToolTipAlreadyShown = false;
                }
                Properties.Settings.Default.MinimizeToTray = MinimizeToTrayCheckBx.Checked;
                Properties.Settings.Default.Save();
            }
        }

        private void MainFrm_Resize(object sender, EventArgs e) {
            if (FormWindowState.Minimized == this.WindowState) {
                if (Properties.Settings.Default.MinimizeToTray) { 
                    notifyIcon.Visible = true;
                    ShowInTaskbar = false;
                    if (!Properties.Settings.Default.ToolTipAlreadyShown) {
                        notifyIcon.ShowBalloonTip(500, "Delphi SyncEdit Button Hider", "DSEBH is still running in the background :)", ToolTipIcon.Info);
                        Properties.Settings.Default.ToolTipAlreadyShown = true;
                        Properties.Settings.Default.Save();
                    }
                    this.Hide();
                }
            } else if (FormWindowState.Normal == this.WindowState) {
                notifyIcon.Visible = false;
                ShowInTaskbar = true;
            }
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e) {
            Show();
            this.WindowState = FormWindowState.Normal;
        }
    }
}
