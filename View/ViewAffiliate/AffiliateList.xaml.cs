using BaseClass.DataAccess;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace View.ViewAffiliate
{
    /// <summary>
    /// Lógica de interacción para AffiliateList.xaml
    /// </summary>
    public partial class AffiliateList : UserControl
    {
        List<Affiliate> affiliateList;

        public AffiliateList()
        {
            InitializeComponent();
            LoadAffiliates();
        }

        private void LoadAffiliates()
        {
            affiliateList = AffiliateService.GetAll();
            dgAffiliates.ItemsSource = affiliateList;
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            NewAffiliate newAffiliate = new NewAffiliate();
            newAffiliate.Show();
        }
    }
}
