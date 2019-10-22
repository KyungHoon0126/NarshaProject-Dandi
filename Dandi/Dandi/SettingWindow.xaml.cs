using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Threading;

namespace Dandi
{
    /// <summary>
    /// Interaction logic for SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : Window
    {
        IntPtr _workerw = IntPtr.Zero;
        IntPtr _desktopWorkerw = IntPtr.Zero;
        private IntPtr _currentHwnd = IntPtr.Zero;

        // 싱글톤 패턴
        private static SettingWindow instance = null;

        private static readonly object padlock = new object();

#if true
        /// <summary>
        /// 싱글톤 패턴
        /// </summary>

        public static SettingWindow Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new SettingWindow();
                    }

                    return instance;
                }
            }
        }

        public SettingWindow()
        {
            instance = this;

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Left = 150;
            this.Top = 150;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            instance = null;
        }

        private void BtnCloseClick(object sender, RoutedEventArgs e)
        {
            SettingWindow.Instance.Close();
            Environment.Exit(0);
            System.Diagnostics.Process.GetCurrentProcess().Kill();
            this.Close();
            InitWorkerW();
            // TODO : 프로그램 종료시 원래 이미지로 돌아가도록 고치기, 밑의 코드랑 같이쓰면 프로그램이 Exit버튼을 눌렀을 때 안꺼짐.
            // int nResult;
            // nResult = WinAPI.SystemParametersInfo(20, 0, "C:\\Users\\user\\Desktop\\모든 파일\\모든 자료\\사진\\윈도우배경화면\\WallPaper10.jpg", 0x1);
        }

        // 현재 사용자의 바탕화면 경로 추출
        public class WinAPI
        {
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            public static extern int SystemParametersInfo
                    (int uAction, int uParam, string IpvParam, int fuWinIni);
        }

#endif

#if true
        /// <summary>
        /// 데이터 로딩 부분
        /// </summary>

        private async void SchoolEventsDataLoading()
        {
            await App.schoolEventsViewModel.SetSchoolEventsList();
        }

        private async void JoinedChannelDataLoading()
        {
            await App.joinedChannelViewModel.SetJoinedChannelList();
        }

#endif

        // 동기화
        public void SchoolDataLoading()
        {
            App.schoolEventsViewModel.SchoolEventsItems.Clear();
            SchoolEventsDataLoading();
        }

        public void ScheduleDataLoading()
        {
            App.joinedChannelViewModel.JoinedChannelItems.Clear();
            App.joinedChannelViewModel.AllChannelScheduleItems.Clear();
            JoinedChannelDataLoading();
        }

        // 동기화 버튼 이벤트
        private void BtnSchoolDataLoadingClick(object sender, RoutedEventArgs e)
        {
            SchoolDataLoading();
        }

        private void BtnChannelDataLoadingClick(object sender, RoutedEventArgs e)
        {
            ScheduleDataLoading();
        }

        // Widget Setting

        private void ComboBoxItemWidgetOne_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
        }

        private void ComboBoxItemWidgetTwo_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
        }

        private void ComboBoxItemWidgetThree_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
        }



        /// <summary>
        /// 바탕화면에 일정들을 나타내기 위한 함수들
        /// </summary>


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

                return false;
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


        private void ShowOnWorkerW()
        {
            var hwnd = GetWindowHandle();
            Debug.WriteLine("curhwnd: " + hwnd.ToInt32());

            W32.SetParent(hwnd, _workerw);
        }
    }
}