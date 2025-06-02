using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projectt
{
    public partial class FlappyDemon : Form
    {
        // DLL imports for window embedding
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        const int GWL_STYLE = -16;
        const int WS_CHILD = 0x40000000;

        Process unityGameProcess;
        IntPtr unityWindowHandle;

        public FlappyDemon()
        {
            InitializeComponent();

            timer1.Start();
            timer2.Start();

            // Subscribe to resize event
            panel3.Resize += panelGameHost_Resize;

            // Launch and embed the Unity game
            string unityGamePath = @"C:\Users\user\Downloads\Base_Game\FlappyDemon.exe"; // Replace this
            EmbedUnityGame(unityGamePath);
        }

        private void EmbedUnityGame(string unityExePath)
        {
            unityGameProcess = Process.Start(unityExePath);

            unityGameProcess.WaitForInputIdle();

            Task.Delay(2000).ContinueWith(_ =>
            {
                unityWindowHandle = unityGameProcess.MainWindowHandle;

                if (unityWindowHandle != IntPtr.Zero)
                {
                    Invoke(new Action(() =>
                    {
                        SetParent(unityWindowHandle, panel3.Handle);

                        SetWindowLong(unityWindowHandle, GWL_STYLE,
                            GetWindowLong(unityWindowHandle, GWL_STYLE) | WS_CHILD);

                        ResizeUnityWindow();
                    }));
                }
            });
        }

        private void ResizeUnityWindow()
        {
            if (unityWindowHandle != IntPtr.Zero)
            {
                MoveWindow(unityWindowHandle, 0, 0, panel3.Width, panel3.Height, true);
            }
        }

        private void panelGameHost_Resize(object sender, EventArgs e)
        {
            ResizeUnityWindow();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Width -= 30;

            if (panel1.Width <= 0)
            {
                panel1.Width = 0;
                timer1.Stop();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            panel2.Left += 30;
            panel2.Width -= 30;

            if (panel2.Width <= 0)
            {
                panel2.Width = 0;
                timer2.Stop();
            }
        }

        private void FlappyDemon_Load(object sender, EventArgs e)
        {

        }
    }
}
