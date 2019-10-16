using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BIND.Core.Login;
using Dandi.Common;
using Dandi.Model;
using Dandi.ViewModel;

namespace Dandi
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Login
        public static LoginData loginData = new LoginData();

        // 현재 사용자의 바탕화면 경로 추출
        public static string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        // AutoLogin
        public App()
        {
            Setting.Load();
        }

        // JoinedChannelsViewModel : 가입 채널 조회
        public static JoinedChannelViewModel joinedChannelViewModel = new JoinedChannelViewModel();

        // SchooolEventsViewModel : 학사 일정
        public static SchoolEventsViewModel schoolEventsViewModel = new SchoolEventsViewModel();

        // MasterControl에 모두 호출하기 위해서 App에 올린다.
        public static ChannelEventsControl channelEventsControl = new ChannelEventsControl();
        public static SchoolEventsContorl schoolEventsContorl = new SchoolEventsContorl();

        // MainWindow.xaml에 호출하기 위해서 App에 올린다. 
        public static MasterControl masterControl = new MasterControl();
    }
}