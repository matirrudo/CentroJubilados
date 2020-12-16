using BaseClass.DataAccess;
using BaseClass.Models;
using BaseClass.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class AffiliateList : UserControl,INotifyPropertyChanged
    {
        private List<Affiliate> affiliateLista;
        public List<Affiliate> AffiliateLista
        {
            get
            {
                return affiliateLista;
            }
            set
            {
                if (affiliateLista != value)
                {
                    affiliateLista = value;
                    OnPropertyChanged();
                }
            }
        }

        public AffiliateList()
        {
            InitializeComponent();
            DataContext = this;
            LoadAffiliates();
        }

        public void LoadAffiliates()
        {
            AffiliateLista = AffiliateService.GetAll();
            CalculateStadistics();
        }

        private void CalculateStadistics()
        {
            int total, activos, comunes, beneficiarios;
            total = affiliateLista.Count;
            activos = affiliateLista.Where(a => a.Active == true).Count();
            comunes = affiliateLista.Where(a => a.TypeOfAffiliateId == 1).Count();
            beneficiarios = affiliateLista.Where(a => a.TypeOfAffiliateId == 2).Count();
            txtTotal.Text = total.ToString();
            txtActivos.Text = activos.ToString();
            txtComunes.Text = comunes.ToString();
            txtBeneficiarios.Text = beneficiarios.ToString();
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            NewAffiliate newAffiliate = new NewAffiliate();
            newAffiliate.DataContext = this;
            newAffiliate.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
