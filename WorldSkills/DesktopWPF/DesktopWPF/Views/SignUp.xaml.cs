using DesktopWPF.Services;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace DesktopWPF
{
    /// <summary>
    /// Логика взаимодействия для SignUp.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUpBtn_Click(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>
            {
                EmailInp.Text,
                PasswordInp.Password.ToString(),
                RoleInp.Text,
                NameInp.Text
            };


            UserServices uServices = new UserServices();

            uServices.AddUser(data);
            uServices.SetCookie();


            NavigationService nav = NavigationService.GetNavigationService(this);

            // TODO: Добавить страницы соотвествующие роли пользователя (средний).

            switch (RoleInp.Text)
            {
                case "Заказчик":
                case "Менеджер":
                case "Кладовщик":
                case "Дирекция":
                    nav.Navigate(new Uri("Views/CustomerScreen.xaml", UriKind.Relative));
                    break;
            }
        }

        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Views/SignIn.xaml", UriKind.Relative));
        }
    }
}