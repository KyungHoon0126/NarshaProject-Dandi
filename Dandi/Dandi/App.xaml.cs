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
        // 굳이 ToggleSwitch Ctrl이 필요한가? 이미 Event가 Schedule이고 ToggleSwitch는 MainHome안에 있어야한다.
        // ToggleSwitch는 UserControl로 MainHome에서 호출되어야 하는건가..?

        // Login
        public static LoginData loginData = new LoginData();

        // AutoLogin
        public App()
        {
            Setting.Load();
        }

        // EventControl
        public static EventViewModel eventViewModel = new EventViewModel();
    }
}