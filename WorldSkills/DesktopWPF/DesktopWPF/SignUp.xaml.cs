using DesktopWPF.Services;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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
                NameInp.Text,
                EmailInp.Text,
                RoleInp.Text,
                PasswordInp.Password.ToString(),
            };


            UserServices uServices = new UserServices();

            uServices.AddUser(data);
        }
    }
}