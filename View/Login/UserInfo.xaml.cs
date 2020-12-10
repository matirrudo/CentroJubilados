using BaseClass.Services;
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

namespace View.Login
{
    /// <summary>
    /// Lógica de interacción para UserInfo.xaml
    /// </summary>
    public partial class UserInfo : UserControl
    {
        public UserInfo()
        {
            InitializeComponent();
            txtUser.Text = LoginService.userLogged.Firstname + " " + LoginService.userLogged.Lastname;
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginService.Logout();
            ShowLoginWindow();
        }

        private void ShowLoginWindow()
        {
            Login login = new Login();
            login.Show();
            Window mainWindow = Window.GetWindow(this);
            mainWindow.Close();
        }
    }
}
