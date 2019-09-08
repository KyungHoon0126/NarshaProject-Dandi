﻿using System;
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
        public static LoginData loginData = new LoginData();

        public App()
        {
            Setting.Load();
        }

        public static ScheduleViewModel personalscheudle = new ScheduleViewModel();
        public static ScheduleViewModel publicschedule = new ScheduleViewModel();
    }
}