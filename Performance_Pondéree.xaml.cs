using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
    /// Logique d'interaction pour Performance_Pondéree.xaml
    /// </summary>
    public partial class Performance_Pondéree : Window
    {
        

        public Performance_Pondéree()
        {
            InitializeComponent();
           
        }
        double PonderationGlobale;
        private void Btn_AjoutMvt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Traitement de la virgule

                MontantMvt.Text = MontantMvt.Text.Replace(".", ",");

                //Affectation des valeurs collectées
                string DataTimeValue = DateMvt.Text;
                double MontantMvtValue = double.Parse(MontantMvt.Text);
                string SensMvtValue = ComboSens.Text;
                int AnneeEnCours = DateTime.Now.Year;

                //Formatage des Valeurs Collectée
                MontantMvt.Text = String.Format("{0:n}", MontantMvtValue);


                //Calcul des temporalités
                if (SensMvtValue == "APPORT")

                {

                    DateTime Date = DateTime.Parse(DateMvt.Text);
                    DateTime Fin = new DateTime(AnneeEnCours, 12, 31);
                    TimeSpan IntervalleA = Fin - Date;
                    int DureeJoursA = IntervalleA.Days;
                    double ApportPondValue = (MontantMvtValue / 365) * DureeJoursA;

                    //MessageBox.Show("Date du mouvement " + Date);
                    //MessageBox.Show("Date de Référence " + Fin);
                    //MessageBox.Show("Duree en jours " + DureeJoursA);
                    //MessageBox.Show("Apport Pondéré " + ApportPondValue);
                    PonderationGlobale = PonderationGlobale + ApportPondValue;
                    //MessageBox.Show("Ponderation Globale : " + PonderationGlobale);


                }

                if (SensMvtValue == "RETRAIT")

                {
                    DateTime Date = DateTime.Parse(DateMvt.Text);
                    DateTime Debut = new DateTime(AnneeEnCours, 01, 01);
                    TimeSpan IntervalleB = Date - Debut;
                    int DureeJoursB = IntervalleB.Days;
                    double RetraitPondValue = (MontantMvtValue / 365) * DureeJoursB;

                    //MessageBox.Show("Date du mouvement " + Date);
                    //MessageBox.Show("Date de Référence " + Debut);
                    //MessageBox.Show("Duree en jours " + DureeJoursB);
                    //MessageBox.Show("Apport Pondéré " + RetraitPondValue);

                    PonderationGlobale = PonderationGlobale - RetraitPondValue;
                    //MessageBox.Show("Ponderation Globale : " + PonderationGlobale);

                }
            }
            catch (Exception ex) { MessageBox.Show("Verifier les Données Saisies SVP"); }



            CumulMvt.Text=PonderationGlobale.ToString("0.00");

        }
        


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ValoInit.Text=string.Empty;
            ValoFinale.Text=string.Empty;
            MontantMvt.Text=string.Empty ;
            DateMvt.Text=string .Empty ;
            CumulMvt.Text = string .Empty ;
            Perf.Text = string .Empty ;
            ComboSens.Text = string .Empty ;
            PonderationGlobale = 0;

        }

        private void Btn_Sortie_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ValoInit_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ValoFinale_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Btn_Perf_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ValoInit.Text = ValoInit.Text.Replace(".", ",");
                ValoFinale.Text = ValoFinale.Text.Replace(".", ",");
                double ValoInitValue = double.Parse(ValoInit.Text);
                double ValoFinaleValue = double.Parse(ValoFinale.Text);
                ValoInit.Text = String.Format("{0:n}", ValoInitValue);
                ValoFinale.Text = String.Format("{0:n}", ValoFinaleValue);
                double PerforamnceEuros = ValoFinaleValue - (ValoInitValue + PonderationGlobale);
                double PerformancePourc = (PerforamnceEuros / ValoInitValue) * 100;
                //MessageBox.Show("Performance de l'Actif : " + PerformancePourc);
                Perf.Text = PerformancePourc.ToString("0.00");
            }
            catch (Exception) { MessageBox.Show("Verifier les Données Saisies SVP"); }
        }
    }
}



