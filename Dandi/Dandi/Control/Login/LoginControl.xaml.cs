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
            // UI 초기화
            InitializeComponent();
            LoginLoaded();
        }

        private void LoginLoaded()
        {
            // 아이디 & 패스워드를 바인딩하기 위해서 DataContext에 loginViewModel을 넣어준다.
            // DataContext : XAML의 UI 요소의 바인딩 구문에서 사용될 수 있는 데이터.
            this.DataContext = App.loginData.loginViewModel;

            // 자동 로그인 확인 함수
            IsAutoLoginChecked();
        }

        private void IsAutoLoginChecked()
        {
            App.loginData.loginViewModel.Id = Settings.Default.userId;
            App.loginData.loginViewModel.Password = Settings.Default.userPw;

            btnAutoLogin.IsChecked = Settings.Default.isAutoLogin;

            // 자동로그인 체크박스가 true이면 Login이 자동으로 실행된다. 
            // 만약 로그인이 실패라면 Main에서 값을 지워준다.
            if (btnAutoLogin.IsChecked == true)
            {
                App.loginData.Login();
            }
        }

        // 로그인 버튼 클릭 함수
        private void Btnlogin_Click(object sender, RoutedEventArgs e)
        {
            // tbid와 tbpw에 입력된 아이디 & 비밀번호를 저장한다.
            Setting.SaveUserdata(tbid.Text, tbpw.Text);

            // ?
            Settings.Default.isAutoLogin = btnAutoLogin.IsChecked.Value;

            // ServerAddress
            Settings.Default.ServerURL = "http://10.80.163.154:5000";

            // ?
            Settings.Default.Save();

            // 로그인 서버 주소
            App.loginData.loginViewModel.ServerAddress = "http://10.80.163.154:5000";

            App.loginData.Login();
        }

        private void Condition_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}