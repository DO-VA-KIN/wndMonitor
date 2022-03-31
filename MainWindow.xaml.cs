using System;
using System.Windows;
using System.Windows.Interop;

namespace wndMonitor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool HookStop = true;

        int activate = 5;
        int clickskipped = 6;
        int created = 3;
        int destroywnd = 4;
        int keyskipped = 7;
        int minmax = 1;
        int movesize = 0;


        public MainWindow()
        {
            InitializeComponent();
        }



        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            HwndSource source = PresentationSource.FromVisual(this) as HwndSource;
            source.AddHook(WndProc);
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (HookStop)
                return IntPtr.Zero;


            if (msg == activate)
            {
                string str = "activate\n" + "msg=" + msg + " hwnd=" + hwnd +
                    " wParam=" + wParam + " lParam=" + lParam + " handled=" + handled;
                listBoxLOG.Items.Add(str);

            }
            if (msg == clickskipped)
            {
                string str = "clickskipped\n" + "msg=" + msg + " hwnd=" + hwnd +
                    " wParam=" + wParam + " lParam=" + lParam + " handled=" + handled;
                listBoxLOG.Items.Add(str);
            }
            if (msg == created)
            {
                string str = "created\n" + "msg=" + msg + " hwnd=" + hwnd +
                    " wParam=" + wParam + " lParam=" + lParam + " handled=" + handled;
                listBoxLOG.Items.Add(str);
            }
            if (msg == destroywnd)
            {
                string str = "destroywnd\n" + "msg=" + msg + " hwnd=" + hwnd +
                    " wParam=" + wParam + " lParam=" + lParam + " handled=" + handled;
                listBoxLOG.Items.Add(str);

            }
            if (msg == keyskipped)
            {
                string str = "keyskipped\n" + "msg=" + msg + " hwnd=" + hwnd +
                    " wParam=" + wParam + " lParam=" + lParam + " handled=" + handled;
                listBoxLOG.Items.Add(str);
            }
            if (msg == minmax)
            {
                string str = "minmax\n" + "msg=" + msg + " hwnd=" + hwnd +
                    " wParam=" + wParam + " lParam=" + lParam + " handled=" + handled;
                listBoxLOG.Items.Add(str);
            }
            if (msg == movesize)
            {
                string str = "movesize\n" + "msg=" + msg + " hwnd=" + hwnd +
                    " wParam=" + wParam + " lParam=" + lParam + " handled=" + handled;
                listBoxLOG.Items.Add(str);
            }

            return IntPtr.Zero;
        }



        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            listBoxLOG.Items.Clear();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            HookStop = false;
            btnStop.IsEnabled = true;
            btnStart.IsEnabled = false;
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            HookStop = true;
            btnStart.IsEnabled = true;
            btnStop.IsEnabled = false;
        }
    }
}
