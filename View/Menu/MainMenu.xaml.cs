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
using View.Login;

namespace View.Menu
{
    /// <summary>
    /// Lógica de interacción para MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        bool menuOpened = false;
        public MainMenu()
        {
            InitializeComponent();
            AddBar();
            CenterWindowOnScreen();
            txtTest.Text = LoginService.userLogged.Firstname;
        }
        
        public void AddBar()
        {
            UserInfo userInfo = new UserInfo();
            stpBar.Children.Add(userInfo);
        }

        private void CenterWindowOnScreen()
        {
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void BtnOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            if (menuOpened)
            {
                grdMenu.Width = 50;
                menuOpened = false;
            }
            else
            {
                grdMenu.Width = 150;
                menuOpened = true;
            }
        }
    }
}
