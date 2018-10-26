using DesktopWPF.Services;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace DesktopWPF
{
    /// <summary>
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignIn : Page
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            UserServices uServices = new UserServices();

            var user = uServices.Get(LoginInp.Text);

            if (user.Count != 0)
            {
                foreach (var u in user)
                {
                    if (u.Key == "Password")
                    {
                        if (u.Value != PasswordInp.Password)
                        {
                            LoginErrorMess.Content = "";
                            PasswordErrorMess.Content = "Неверный пароль.";
                        }
                        else
                        {
                            NavigationService nav = NavigationService.GetNavigationService(this);
                            nav.Navigate(new Uri("Views/CustomerScreen.xaml", UriKind.Relative));

                            uServices.SetCookie();
                        }
                        break;
                    }
                }
            }
            else
            {
                PasswordErrorMess.Content = "";
                LoginErrorMess.Content = "Пользователя с таким Email нет в базе.";
            }
        }
    }
}
