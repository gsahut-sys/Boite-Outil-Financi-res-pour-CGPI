using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ProjetCGPI_v0
{
    /// <summary>
    /// Logique d'interaction pour Documentation.xaml
    /// </summary>
    public partial class Documentation : Window
    {
        public Documentation()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Services_Publics_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("http://www.service-public.fr/particuliers/vosdroits/F22414")
            {
                UseShellExecute=true

            });

        }

        private void Btn_Doc_Economie_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("http://www.economie.gouv.fr/cedef/assurance-vie")
            {
                UseShellExecute = true

            });
        }

        private void Service_Pub_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.service-public.fr/particuliers/vosdroits/F15274")
            {
                UseShellExecute = true

            });
        }

        private void Btn_2041GG_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://www.impots.gouv.fr/formulaire/2041-gg/revenus-dactivite-et-de-remplacement-de-source-etrangere")
            {
                UseShellExecute = true

            });
        }
    }
}
