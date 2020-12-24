using BaseClass.Models;
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
using System.Windows.Shapes;

namespace View.ViewAffiliate
{
    /// <summary>
    /// Lógica de interacción para AffiliateInfo.xaml
    /// </summary>
    public partial class AffiliateInfo : Window, INotifyPropertyChanged
    {
        
        private Affiliate affiliate;
        public Affiliate Affiliate
        {
            get
            {
                return affiliate;
            }
            set
            {
                if (affiliate != value)
                {
                    affiliate = value;
                    OnPropertyChanged();
                }
            }
        }
        private List<Workshop> workshops;
        public List<Workshop> Workshops
        {
            get
            {
                return workshops;
            }
            set
            {
                if (workshops != value)
                {
                    workshops = value;
                    OnPropertyChanged();
                }
            }
        }

        private List<Subscription> subscriptions;
        public List<Subscription> Subscriptions
        {
            get
            {
                return subscriptions;
            }
            set
            {
                if (subscriptions != value)
                {
                    subscriptions = value;
                    OnPropertyChanged();
                }
            }
        }

        public AffiliateInfo()
        {
            InitializeComponent();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void LoadAffiliate()
        {
            txtFistname.Text = Affiliate.Firstname;
            txtLastname.Text = Affiliate.Lastname;
            txtDNI.Text = Affiliate.DNI;
            txtBeneficio.Text = Affiliate.BenefitNumber;
            txtBirthdate.Text = Affiliate.Birthdate.ToShortDateString();
            txtAge.Text = ((DateTime.Today - Affiliate.Birthdate).Days / 365).ToString();
            txtAddress.Text = Affiliate.Address;
            txtPhoneNumber.Text = Affiliate.PhoneNumber;
            txtActive.Text = Affiliate.Active.ToString();
            txtRegistrationDate.Text = Affiliate.RegistrationDate.ToShortDateString();
            Workshops = Affiliate.Workshop;
            Subscriptions = Affiliate.Subscription;
            dgWorkshops.ItemsSource = Workshops;
            dgSubscriptions.ItemsSource = Subscriptions;

            Subscription sub = new Subscription
            {
                Month = "Noviembre",
                Year = 2020,
                Amount = 250.00m,
                PaymentDate = DateTime.Now
            };
            Subscriptions.Add(sub);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Topmost = true;
        }
    }
}
