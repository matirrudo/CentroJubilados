using BaseClass.Services;
using MaterialDesignThemes.Wpf;
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
            CreateMenuList();
        }
        
        public void AddBar()
        {
            UserInfo userInfo = new UserInfo();
            stpBar.Children.Add(userInfo);
        }

        public void CreateMenuList()
        {
            if (LoginService.userLogged.Rol.Name.Equals("administrador"))
                CreateAdminMenuList();
        }

        public void CreateAdminMenuList()
        {
            menuList.Items.Add(CreateItemMenu("Afiliados", PackIconKind.AccountGroup)); 
            menuList.Items.Add(CreateItemMenu("Cuetas", PackIconKind.CashUsd));
            menuList.Items.Add(CreateItemMenu("Talleres", PackIconKind.HammerWrench));
            menuList.Items.Add(CreateItemMenu("Cuentas", PackIconKind.AccountEdit));
        }

        public ListViewItem CreateItemMenu(String title, PackIconKind icon )
        {
            ListViewItem listViewItem = new ListViewItem();
            StackPanel stackPanel = new StackPanel();
            TextBlock txtTitle = new TextBlock
            {
                Text = title,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(10),
                Foreground = Brushes.White,
                FontSize = 16,
            };
            PackIcon packIcon = new PackIcon
            {
                Kind = icon,
                Width = 25,
                Height = 25,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(5),
                Foreground = Brushes.White
            };
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.Children.Add(packIcon);
            stackPanel.Children.Add(txtTitle);
            listViewItem.Content = stackPanel;
            return listViewItem;
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
