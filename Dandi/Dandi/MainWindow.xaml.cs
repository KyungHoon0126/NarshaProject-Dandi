using Dandi.Properties;
using Dandi.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Dandi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IntPtr _workerw = IntPtr.Zero;
        IntPtr _desktopWorkerw = IntPtr.Zero;
        private IntPtr _currentHwnd = IntPtr.Zero;

        public MainWindow()
        {
            InitializeComponent();
            InitWorkerW();
            InitOnDisplaySettingChanged();

            // this.Loaded += MainWindow_Loaded;

            App.loginData.loginViewModel.OnLoginResultRecieved += LoginViewModel_OnLoginResultRecieved;
        }

        // 분노의 일정 테스트
        //public async void AA()
        //{
        //    EventViewModel eventView = new EventViewModel();
        //    await eventView.SetBusTypeList();
        //}

        public void LoginViewModel_OnLoginResultRecieved(object sender, bool success)
        {
            if(success)
            {
                // 분노의 일정 테스트
                // AA();

                MessageBox.Show("로그인에 성공하셨습니다.");
                ctrlLogin.Visibility = Visibility.Collapsed;
                ctrlSchedule.Visibility = Visibility.Visible;
                UpdateScreen();
                MainWindow_Loaded();

            }
            else
            {
                MessageBox.Show("로그인에 실패하셨습니다.");
                Settings.Default.isAutoLogin = false;
                Settings.Default.userId = string.Empty;
                Settings.Default.userPw = string.Empty;
                Settings.Default.Save();
            }
        }
        
        private void MainWindow_Loaded()
        {
            ShowOnWorkerW();
            FillDisplay();
        }

        private void UpdateScreen()
        {
            // Background = "Transparent"
            // ResizeMode = "NoResize"
            // WindowState = "Maximized"
            // WindowStyle = "None"
            // AllowsTransparency = "True"
            // Foreground = "White"

            this.Background = Brushes.Transparent;
            this.ResizeMode = ResizeMode.NoResize;
            this.WindowState = WindowState.Maximized;
            this.WindowStyle = WindowStyle.None;
            this.Foreground = Brushes.White;
        }

        private void InitOnDisplaySettingChanged()
        {
            SystemEvents.DisplaySettingsChanged += SystemEvents_DisplaySettingsChanged;
        }

        private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(FillDisplay));
        }

        private void InitWorkerW()
        {
            // Fetch the Progman window
            var progman = W32.FindWindow("Progman", null);
            var result = IntPtr.Zero;

            // Send 0x052C to Progman. This message directs Progman to spawn a 
            // WorkerW behind the desktop icons. If it is already there, nothing 
            // happens.
            W32.SendMessageTimeout(progman,
                                   0x052C,
                                   new IntPtr(0),
                                   IntPtr.Zero,
                                   W32.SendMessageTimeoutFlags.SMTO_NORMAL,
                                   1000,
                                   out result);


            // We enumerate all Windows, until we find one, that has the SHELLDLL_DefView 
            // as a child. 
            // If we found that window, we take its next sibling and assign it to workerw.
            W32.EnumWindows(new W32.EnumWindowsProc((tophandle, topparamhandle) =>
            {
                var p = W32.FindWindowEx(tophandle,
                                            IntPtr.Zero,
                                            "SHELLDLL_DefView",
                                            IntPtr.Zero);

                if (p != IntPtr.Zero)
                {
                    // Gets the SHELLDLL_DefView's WorkerW;
                    _desktopWorkerw = W32.GetParent(p);

                    // Gets the WorkerW Window after the current one.
                    _workerw = W32.FindWindowEx(IntPtr.Zero,
                                               tophandle,
                                               "WorkerW",
                                               IntPtr.Zero);
                }

                return true;
            }), IntPtr.Zero);

            // We now have the handle of the WorkerW behind the desktop icons.
            // We can use it to create a directx device to render 3d output to it, 
            // we can use the System.Drawing classes to directly draw onto it, 
            // and of course we can set it as the parent of a windows form.
            //
            // There is only one restriction. The window behind the desktop icons d oes
            // NOT receive any user input. So if you want to capture mouse movement, 
            // it has to be done the LowLevel way (WH_MOUSE_LL, WH_KEYBOARD_LL).
        }

        private IntPtr GetWindowHandle()
        {
            if (_currentHwnd != IntPtr.Zero) return _currentHwnd;
            var window = Window.GetWindow(this);
            _currentHwnd = new WindowInteropHelper(window).EnsureHandle();

            return _currentHwnd;
        }

        //Temporary
        private void FillDisplay()
        {
            var point = System.Windows.Forms.Cursor.Position;
            System.Windows.Forms.Screen screen = System.Windows.Forms.Screen.FromPoint(point);
            var area = screen.WorkingArea;

            W32.SetWindowPos(_workerw, W32.HWND.Bottom, area.X, area.Y, area.Width, area.Height, 0);
            this.Top = area.Top;
            this.Left = area.Left;
            this.Width = area.Width;
            this.Height = area.Height;
        }

        private void ShowOnWorkerW()
        {
            var hwnd = GetWindowHandle();
            Debug.WriteLine("curhwnd: " + hwnd.ToInt32());

            W32.SetParent(hwnd, _workerw);
        }
    }
}
