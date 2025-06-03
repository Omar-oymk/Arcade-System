using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Projectt
{
    public partial class FlappyDemon : Form
    {
        #region dll window embedding
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
        #endregion

        SoundPlayer drums;
        public FlappyDemon()
        {
            InitializeComponent();

            drums = new SoundPlayer(@"C:\Users\user\Downloads\Arcade Project\Assets\Music\Drums.wav");
            drums.Play();

            var handle = panel3.Handle; // force handle creation

            // open this window in full screen
            this.WindowState = FormWindowState.Maximized;

            // timers for panel animations
            timer1.Start();
            timer2.Start();

            // Subscribe to resize event
            panel3.Resize += panelGameHost_Resize;

            // subscribe to another event (custom) that closes the unity window 
            this.FormClosing += FlappyDemon_FormClosing;
        }

        private void FlappyDemon_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (unityGameProcess != null && !unityGameProcess.HasExited)
                {
                    unityGameProcess.Kill();
                    unityGameProcess.Dispose();
                    unityGameProcess = null;
                    unityWindowHandle = IntPtr.Zero; 
                }
            }
            catch (Exception ex)
            {
                // Log or ignore exceptions here
            }
        }

        private async void EmbedUnityGame(string unityExePath)
        {
            // CHECK FIRST IF AN OLDER GAME WINDOW IS STILL OPENED IF YES KILL IT
            if (unityGameProcess != null && !unityGameProcess.HasExited)
            {
                // Clean old process before starting a new one
                unityGameProcess.Kill();
                unityGameProcess.Dispose();
                unityGameProcess = null;
                unityWindowHandle = IntPtr.Zero;
                await Task.Delay(4000); // wait 4 second for OS to clean up
            }


            unityGameProcess = Process.Start(unityExePath);

            // Wait until the main window handle is available and valid
            for (int i = 0; i < 60; i++) // try for up to ~10 seconds
            {
                await Task.Delay(500);
                unityGameProcess.Refresh();

                if (unityGameProcess.MainWindowHandle != IntPtr.Zero)
                {
                    unityWindowHandle = unityGameProcess.MainWindowHandle;
                    break;
                }
            }

            if (unityWindowHandle == IntPtr.Zero)
            {
                MessageBox.Show("Failed to find Unity game window.");
                return;
            }

            // Embed into panel
            SetParent(unityWindowHandle, panel3.Handle);

            // Set style to child window
            int style = GetWindowLong(unityWindowHandle, GWL_STYLE);
            SetWindowLong(unityWindowHandle, GWL_STYLE, style | WS_CHILD);

            // IMPORTANT: force window to repaint fully in case Unity delays graphics
            await Task.Delay(500); // give Unity time to initialize inside the panel
            ResizeUnityWindow();
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
            // Launch and embed the Unity game
            string unityGamePath = @"C:\Users\user\Downloads\Base_Game\FlappyDemon.exe"; // Replace this
            EmbedUnityGame(unityGamePath);
        }
    }
}
