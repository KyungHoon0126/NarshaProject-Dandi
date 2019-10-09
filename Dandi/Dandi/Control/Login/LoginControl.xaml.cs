using Dandi.Common;
using Dandi.Properties;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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
            // Binding을 하지 않았기 때문에 변수에 담아서 넘긴다.
            string temp = pbpw.Password;

            // tbid와 tbpw에 입력된 아이디 & 비밀번호를 저장한다.
            Setting.SaveUserdata(tbid.Text, temp);

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


        public class PasswordBoxMonitor : DependencyObject
        {
            public static bool GetIsMonitoring(DependencyObject obj)
            {
                return (bool)obj.GetValue(IsMonitoringProperty);
            }

            public static void SetIsMonitoring(DependencyObject obj, bool value)
            {
                obj.SetValue(IsMonitoringProperty, value);
            }

            public static readonly DependencyProperty IsMonitoringProperty =
                DependencyProperty.RegisterAttached("IsMonitoring", typeof(bool), typeof(PasswordBoxMonitor), new UIPropertyMetadata(false, OnIsMonitoringChanged));


            public static int GetPasswordLength(DependencyObject obj)
            {
                return (int)obj.GetValue(PasswordLengthProperty);
            }

            public static void SetPasswordLength(DependencyObject obj, int value)
            {
                obj.SetValue(PasswordLengthProperty, value);
            }

            public static readonly DependencyProperty PasswordLengthProperty =
                DependencyProperty.RegisterAttached("PasswordLength", typeof(int), typeof(PasswordBoxMonitor), new UIPropertyMetadata(0));

            private static void OnIsMonitoringChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var pb = d as PasswordBox;
                if (pb == null)
                {
                    return;
                }
                if ((bool)e.NewValue)
                {
                    pb.PasswordChanged += PasswordChanged;
                }
                else
                {
                    pb.PasswordChanged -= PasswordChanged;
                }
            }

            static void PasswordChanged(object sender, RoutedEventArgs e)
            {
                var pb = sender as PasswordBox;
                if (pb == null)
                {
                    return;
                }
                SetPasswordLength(pb, pb.Password.Length);
            }
        }


        // PasswordHelper
        //public class PasswordHelper : DependencyObject
        //{
        //    public static readonly DependencyProperty PasswordProperty =
        //        DependencyProperty.RegisterAttached("Password",
        //        typeof(string), typeof(PasswordHelper),
        //        new FrameworkPropertyMetadata(string.Empty, OnPasswordPropertyChanged));

        //    public static readonly DependencyProperty AttachProperty =
        //        DependencyProperty.RegisterAttached("Attach",
        //        typeof(bool), typeof(PasswordHelper), new PropertyMetadata(false, Attach));

        //    private static readonly DependencyProperty IsUpdatingProperty =
        //       DependencyProperty.RegisterAttached("IsUpdating", typeof(bool),
        //       typeof(PasswordHelper));


        //    public static void SetAttach(DependencyObject dp, bool value)
        //    {
        //        dp.SetValue(AttachProperty, value);
        //    }

        //    public static bool GetAttach(DependencyObject dp)
        //    {
        //        return (bool)dp.GetValue(AttachProperty);
        //    }

        //    public static string GetPassword(DependencyObject dp)
        //    {
        //        return (string)dp.GetValue(PasswordProperty);
        //    }

        //    public static void SetPassword(DependencyObject dp, string value)
        //    {
        //        dp.SetValue(PasswordProperty, value);
        //    }

        //    private static bool GetIsUpdating(DependencyObject dp)
        //    {
        //        return (bool)dp.GetValue(IsUpdatingProperty);
        //    }

        //    private static void SetIsUpdating(DependencyObject dp, bool value)
        //    {
        //        dp.SetValue(IsUpdatingProperty, value);
        //    }

        //    private static void OnPasswordPropertyChanged(DependencyObject sender,
        //        DependencyPropertyChangedEventArgs e)
        //    {
        //        PasswordBox passwordBox = sender as PasswordBox;
        //        passwordBox.PasswordChanged -= PasswordChanged;

        //        if (!(bool)GetIsUpdating(passwordBox))
        //        {
        //            passwordBox.Password = (string)e.NewValue;
        //        }
        //        passwordBox.PasswordChanged += PasswordChanged;
        //    }

        //    private static void Attach(DependencyObject sender,
        //        DependencyPropertyChangedEventArgs e)
        //    {
        //        PasswordBox passwordBox = sender as PasswordBox;

        //        if (passwordBox == null)
        //            return;

        //        if ((bool)e.OldValue)
        //        {
        //            passwordBox.PasswordChanged -= PasswordChanged;
        //        }

        //        if ((bool)e.NewValue)
        //        {
        //            passwordBox.PasswordChanged += PasswordChanged;
        //        }
        //    }

        //    private static void PasswordChanged(object sender, RoutedEventArgs e)
        //    {
        //        PasswordBox passwordBox = sender as PasswordBox;
        //        SetIsUpdating(passwordBox, true);
        //        SetPassword(passwordBox, passwordBox.Password);
        //        SetIsUpdating(passwordBox, false);
        //    }
        //}
    }
}