using InstrumentCatalog.ViewModel;
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

namespace InstrumentCatalog
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            string source = Properties.Settings.Default.DAOFilename;
            BLC.BLC blc = new BLC.BLC(source);
            InstrumentListViewModel ilvm = new InstrumentListViewModel(blc);

            InitializeComponent();
            DataContext = ilvm;
        }

    }
}
