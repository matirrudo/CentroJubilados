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
using View.ViewAffiliate;
using View.ViewLogs;
using View.ViewNotes;
using View.ViewPayment;
using View.ViewUser;
using View.ViewWorkshop;

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
            AffiliateList affiliateList = new AffiliateList();
            stpViewScreen.Children.Add(affiliateList);
            menuList.Items.Add(CreateItemMenu("Afiliados", PackIconKind.AccountGroup, affiliateList)); 
            menuList.Items.Add(CreateItemMenu("Cuotas", PackIconKind.CashUsd, new PaymentList()));
            menuList.Items.Add(CreateItemMenu("Talleres", PackIconKind.HammerWrench, new WorkshopList()));
            menuList.Items.Add(CreateItemMenu("Notas", PackIconKind.Book, new NoteList()));
            menuList.Items.Add(CreateItemMenu("Cuentas", PackIconKind.AccountEdit, new UserList()));
            menuList.Items.Add(CreateItemMenu("Registros", PackIconKind.ClipboardList, new LogList()));
            menuList.SelectionChanged += new SelectionChangedEventHandler(MenuList_SelectionChanged);
        }

        private void MenuList_SelectionChanged(object sender, RoutedEventArgs e)
        {
            ListViewItem listViewItem = (ListViewItem)((ListView)sender).SelectedItem;
            ChangeScreen((UserControl)listViewItem.DataContext);
        }

        public ListViewItem CreateItemMenu(string title, PackIconKind icon, UserControl userControl)
        {
            StackPanel stackPanel = new StackPanel();
            ListViewItem listViewItem = new ListViewItem();
            listViewItem.DataContext = userControl;
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

        private void ChangeScreen(UserControl userControl)
        {
            stpViewScreen.Children.Clear();
            stpViewScreen.Children.Add(userControl);
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
