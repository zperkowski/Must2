using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InstrumentCatalog
{
    public partial class Must2WPF : Window
    {
        public void MainWindow()
        {
            string source = Properties.Settings.Default.DAOFilename;
            BLC blc = new BLC(source);
            InstrumentListViewModel ilvm = new InstrumentListViewModel(blc);

            DataContext = ilvm;
        }
    }
}
