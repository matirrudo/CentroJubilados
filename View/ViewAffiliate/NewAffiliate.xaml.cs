using BaseClass.Models;
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

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            affiliate.Firstaname = txtNombre.Text;
            MessageBox.Show("OBJ: " + affiliate.Firstaname);
            this.Close();
        }
    }
}
