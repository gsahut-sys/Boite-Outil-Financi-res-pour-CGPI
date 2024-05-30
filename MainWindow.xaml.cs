using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetCGPI_v0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnPerf_Click(object sender, RoutedEventArgs e)
        {
            
            Performance performance1 = new Performance();
            performance1.Show();

        }

        private void Btn_Sortie_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnPerfPond_Click(object sender, RoutedEventArgs e)
        {
            Performance_Pondéree performance2= new Performance_Pondéree();
            performance2.Show();
        }

        private void BtnRachatAV_Click(object sender, RoutedEventArgs e)
        {
              DispatchAV Dispatch1 = new DispatchAV();
                Dispatch1.Show();
        }

        private void BtnSuccessAV_Click(object sender, RoutedEventArgs e)
        {
            FiscaliteDcAV FiscaliteDeces = new FiscaliteDcAV();
            FiscaliteDeces.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PensionsE Retraites = new PensionsE();
            Retraites.Show();
        }

        private void BtnDocumentation_Click(object sender, RoutedEventArgs e)
        {
            Documentation documentation = new Documentation();
            documentation.Show();

        }
    }
}