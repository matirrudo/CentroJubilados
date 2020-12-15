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
using System.Windows.Shapes;

namespace View.ViewAffiliate
{
    /// <summary>
    /// Lógica de interacción para NewAffiliate.xaml
    /// </summary>
    public partial class NewAffiliate : Window
    {
        Affiliate affiliate;

        public NewAffiliate()
        {
            affiliate = new Affiliate();
            InitializeComponent();
            LoadTypesOfAffiliado();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Agregar nuevo Afiliado: " + txtApellido.Text + " " + txtNombre.Text + " DNI: " + txtDni.Text , "Confirmar nuevo Afiliado", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result.Equals(MessageBoxResult.OK)){
                affiliate.Firstaname = txtNombre.Text;
                affiliate.Lastname = txtApellido.Text;
                affiliate.DNI = txtDni.Text;
                affiliate.BenefitNumber = txtBeneficiario.Text;
                affiliate.Birthdate = (DateTime)dtpNacimiento.SelectedDate;
                affiliate.Address = txtDireccion.Text;
                affiliate.PhoneNumber = txtTelefono.Text;
                affiliate.TypeOfAffiliateId = (cmbTypeOfAffiliate.SelectedItem as TypeOfAffiliate).Id;
                affiliate.Active = (bool)tgActivo.IsChecked;
                affiliate.RegistrationDate = DateTime.Now; 
                AffiliateService.Add(affiliate);
                AffiliateList affiliateList = this.DataContext as AffiliateList;
                affiliateList.LoadAffiliates();
                this.Close();
            }
        }

        private void LoadTypesOfAffiliado()
        {
            WorkTypeOfAffiliate wa = new WorkTypeOfAffiliate();
            cmbTypeOfAffiliate.ItemsSource = wa.GetAll();
        }
    }
}
