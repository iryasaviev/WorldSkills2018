using DesktopWPF.Services;
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

            if (user != null)
            {
                foreach (var u in user)
                {
                    if (u.Key == "Password")
                    {
                        if (u.Value != PasswordInp.Password)
                        {
                            // TODO: Вывести ошибку о неправильном пароле (высокий).
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                // TODO: Вывести ошибку об отсутствии введенного логина в базе (высокий).
            }
        }
    }
}
