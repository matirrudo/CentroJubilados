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

namespace View.ViewLogs
{
    /// <summary>
    /// Lógica de interacción para LogList.xaml
    /// </summary>
    public partial class LogList : UserControl, INotifyPropertyChanged
    {
        private List<Log> logs;
        public List<Log> Logs
        {
            get
            {
                return logs;
            }
            set
            {
                if (logs != value)
                {
                    logs = value;
                    OnPropertyChanged();
                }
            }
        }
        public LogList()
        {
            InitializeComponent();
            LoadLogs();
        }

        public void LoadLogs()
        {
            Logs = LogService.GetLogs();
            dgLogs.ItemsSource = Logs; 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
