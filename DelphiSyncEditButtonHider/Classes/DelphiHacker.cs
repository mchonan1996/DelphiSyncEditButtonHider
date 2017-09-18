using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DelphiSyncEditButtonHider.Classes {
    class DelphiHacker {

        private delegate bool Win32Callback(IntPtr hwnd, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int FindWindowEx(int hwndParent, int hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll")]
        static extern bool ShowWindowAsync(int hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        static extern int GetForegroundWindow();

        private const int SW_HIDE = 0;

        public void DoHideSyncButton() {
            try {
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
                    return;
                }
                var level7 = level7Children[0];

                // Second panel in the child7List holds the 8th child.
                var level8 = FindWindowEx(level7, 0, "TPanel", null);

                var level9Children = GetAllChildrenHandles(level8, null);
                if (level9Children.Count < 1) {
                    return;
                }
                var level9 = level9Children[0];
                var level10 = FindWindowEx(level9, 0, "TSyncButton", null);
                ShowWindowAsync(level10, SW_HIDE);
            }
            catch {
                // Don't do anything. I don't really care.
            }
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
                prevChild = currChild; ;
            }
            while (true);

            return list;
        }
    }
}
