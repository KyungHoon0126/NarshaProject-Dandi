using Dandi.Common;
using Dandi.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dandi
{
    /// <summary>
    /// Interaction logic for LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
            Loaded();
        }

#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        private void Loaded()
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword
        {
            this.DataContext = App.loginData.loginViewModel;
            IsAutoLoginChecked();
        }

        private void IsAutoLoginChecked()
        {
            App.loginData.loginViewModel.Id = Settings.Default.userId;
            App.loginData.loginViewModel.Password = Settings.Default.userPw;
            btnAutoLogin.IsChecked = Settings.Default.isAutoLogin;

            if (btnAutoLogin.IsChecked == true)
            {
                App.loginData.Login();
            }
        }

        private void Btnlogin_Click(object sender, RoutedEventArgs e)
        {
            Setting.SaveUserdata(tbid.Text, tbpw.Text);

            Settings.Default.isAutoLogin = btnAutoLogin.IsChecked.Value;
            Settings.Default.ServerURL = "http://10.80.162.124:5000";

            Settings.Default.Save();


            App.loginData.loginViewModel.ServerAddress = "http://10.80.162.124:5000";

            App.loginData.Login();
        }
    }
}