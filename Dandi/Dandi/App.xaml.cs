using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using BIND.Core.Login;
using Dandi.Common;
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

        // AutoLogin
        public App()
        {
            Setting.Load();
        }

        // ChannelEventsControl : 채널 이벤트 조회 events, channel
        public static channelViewModel channelViewModel = new channelViewModel();

        // JoinedChannelsViewModel : 가입 채널 조회
        public static JoinedChannelViewModel joinedChannelViewModel = new JoinedChannelViewModel();

        // SchooolEventsViewModel : 학사 일정
        public static SchoolEventsViewModel schoolEventsViewModel = new SchoolEventsViewModel();
    }
}