using Dandi.Common;
using Dandi.Properties;
using System.Windows;
using System.Windows.Controls;

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
            LoginLoaded();
        }

        private void LoginLoaded()
        {
            // Id & Pw Binding을 하기 위함.
            this.DataContext = App.loginData.loginViewModel;
            IsAutoLoginChecked();
        }

        // AutoLoginChecked
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
            // User id, pw Saving
            Setting.SaveUserdata(tbid.Text, tbpw.Text);

            Settings.Default.isAutoLogin = btnAutoLogin.IsChecked.Value;

            // ServerAddress
            Settings.Default.ServerURL = "http://10.80.163.154:5000";

            // SaveFunction
            Settings.Default.Save();

            // LoginServerAddress
            App.loginData.loginViewModel.ServerAddress = "http://10.80.163.154:5000";

            // LoginFunction
            App.loginData.Login();
        }
    }
}