using Microsoft.VisualBasic;
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

namespace ProjetCGPI_v0
{
    /// <summary>
    /// Logique d'interaction pour Performance.xaml
    /// </summary>
    public partial class Performance : Window
    {
        public Performance()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ValoInit_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

       
    

        private void Btn_CalculPerf_Click_1(object sender, RoutedEventArgs e)
        {
            ValoInit.Text = ValoInit.Text.Replace(".", ",");
            String ValoInitTxt = ValoInit.Text;
            Double ValeurInitiale = Double.Parse(ValoInitTxt);
            ValoInit.Text = String.Format("{0:#,###0}", ValeurInitiale);

            ValoFinale.Text = ValoFinale.Text.Replace(".", ",");
            String ValoFinaleTxt = ValoFinale.Text;
            Double ValeurFinale = Double.Parse(ValoFinaleTxt);
            ValoFinale.Text = String.Format("{0:#,###0}", ValeurFinale);


            Apports.Text=Apports.Text.Replace(".", ",");
            
            String ApportTxt = Apports.Text;
            Double Apport = Double.Parse(ApportTxt);
            Apports.Text = String.Format("{0:#,###0}", Apport);

            Retraits.Text=Retraits.Text.Replace(".", ",");
            
            String RetraitTxt = Retraits.Text;
            Double Retrait = Double.Parse(RetraitTxt);
            Retraits.Text = String.Format("{0:#,###0}", Retrait);


            Double PerfEuros = (ValeurFinale - (ValeurInitiale + Apport - Retrait));
            Double PerfPourcent = (PerfEuros / ValeurInitiale) * 100;

            PerfResultat.Text = PerfPourcent.ToString("0.00");

            ///MessageBox.Show(PerfPourcent.ToString(),"%");

        }

        private void Btn_NxCalcul_Click_1(object sender, RoutedEventArgs e)
        {
            ValoInit.Text = string.Empty;
            ValoFinale.Text = string.Empty;
            Apports.Text = "0";
            Retraits.Text = "0";
            PerfResultat.Text = string.Empty;
        }

        private void Btn_Sortie_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
