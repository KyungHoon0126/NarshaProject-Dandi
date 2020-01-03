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

            // TODO : 프로그램 종료시 원래 이미지로 돌아가도록 고치기, 밑의 코드랑 같이쓰면 프로그램이 Exit버튼을 눌렀을 때 안꺼짐.
            // int nResult;
            //nResult = WinAPI.SystemParametersInfo(20, 0, "C:\\Users\\user\\Desktop\\모든 파일\\모든 자료\\사진\\윈도우배경화면\\WallPaper10.jpg", 0x1);
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



        /// <summary>
        /// Widget Setting
        /// </summary>

        // 1
        private void ComboBoxItemWidgetOne_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
        }
        // 2
        private void ComboBoxItemWidgetTwo_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
        }
        // 3
        private void ComboBoxItemWidgetThree_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
        }
    }
}