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
        private List<Affiliate> affiliateListaAux;
        public List<Affiliate> AffiliateListaAux
        {
            get
            {
                return affiliateListaAux;
            }
            set
            {
                if (affiliateListaAux != value)
                {
                    affiliateListaAux = value;
                    OnPropertyChanged();
                }
            }
        }

        public AffiliateList()
        {
            InitializeComponent();
            DataContext = this;
            LoadAffiliates();
            affiliateListaAux = new List<Affiliate>();
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

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            if (txtBuscar.Text == "" || txtBuscar.Text is null)
            {
                dgAffiliates.ItemsSource = affiliateLista;
                LoadAffiliates();
            }
            else
            {
                affiliateListaAux.Clear();
                for (int i = 0; i < affiliateLista.Count; i++)
                {
                    if (affiliateLista.ElementAt(i).DNI.ToLower().Equals(txtBuscar.Text.ToLower()) ||
                        affiliateLista.ElementAt(i).Firstname.ToLower().Equals(txtBuscar.Text.ToLower()) ||
                        affiliateLista.ElementAt(i).Lastname.ToLower().Equals(txtBuscar.Text.ToLower()))
                    {
                        affiliateListaAux.Add(affiliateLista.ElementAt(i));
                    }
                }
                dgAffiliates.ItemsSource = affiliateListaAux;
            }
        }

        private void TxtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBuscar.Text == "" || txtBuscar.Text is null)
            {
                dgAffiliates.ItemsSource = AffiliateLista;
                LoadAffiliates();
            }
        }

        private void ItemShow_Selected(object sender, RoutedEventArgs e)
        {
            AffiliateInfo affiliateInfo = new AffiliateInfo
            {
                Affiliate = (sender as FrameworkElement).DataContext as Affiliate
            };
            affiliateInfo.LoadAffiliate();
            affiliateInfo.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
