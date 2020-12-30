using BaseClass.Models;
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
using System.Windows.Shapes;
using View.Menu;

namespace View.Login
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            VerifyRemember();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (LoginService.Login(txtUsername.Text, txtPassword.Password,(bool) cbRemember.IsChecked))
            {
                ShowMainMenu();
            }
            else
                MessageBox.Show("Usuario o contraseña incorrectos");
        }

        private void ShowMainMenu()
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
            this.Close();
        }

        private void VerifyRemember()
        {
            User user = SettingService.GetSetting().User;
            if(!(user is null))
            {
                LoginService.userLogged = user;
                LogService.AddLog("Entrada al sistema ", "Entrada al sistema de " + user.Lastname + " " + user.Firstname, user);
                ShowMainMenu();
            }
        }
    }
}
