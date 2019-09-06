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
            this.DataContext = App.loginData.loginViewModel;
        }

        private void Btnlogin_Click(object sender, RoutedEventArgs e)
        {
            //string Id = tbid.Text;
            //string Pw = tbid.Text;

            //App.loginData.loginViewModel.Id = Id;
            //App.loginData.loginViewModel.Password = Pw;

            App.loginData.loginViewModel.ServerAddress = "http://10.80.162.124:5000";

            App.loginData.Login();
        }
    }
}
