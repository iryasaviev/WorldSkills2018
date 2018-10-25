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
            List<string> data = new List<string>();

            data.Add(NameInp.Text);
            data.Add(EmailInp.Text);
            data.Add(NameInp.Text);

            UserServices uServices = new UserServices();

            uServices.AddUser(data);
        }
    }
}
