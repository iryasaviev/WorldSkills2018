using DesktopWPF.Services;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace DesktopWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для CustomerScreen.xaml
    /// </summary>
    public partial class CustomerScreen : Page
    {
        public CustomerScreen()
        {
            InitializeComponent();
        }

        private void MenuExitBtn_Click(object sender, RoutedEventArgs e)
        {
            UserServices uServices = new UserServices();

            uServices.DelCookie();

            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("SignIn.xaml", UriKind.Relative));
        }
    }
}
