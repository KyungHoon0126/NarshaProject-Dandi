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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Dandi
{
    /// <summary>
    /// Interaction logic for SettingWindow.xaml
    /// </summary>
    public partial class SettingWindow : Window
    {
        // 싱글톤 패턴
        static SettingWindow instance = null;
        static readonly object padlock = new object();

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
    }
}
