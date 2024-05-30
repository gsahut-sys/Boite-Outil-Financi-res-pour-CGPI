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
    /// Logique d'interaction pour RachatAP.xaml
    /// </summary>
    public partial class RachatAP : Window
    {
        public RachatAP()
        {
            InitializeComponent();
        }

        private void Btn_CalculsM_Click(object sender, RoutedEventArgs e)
        {
            //Traitement de la virgule**********************************
            ValoContratM.Text = ValoContratM.Text.Replace(".", ",");
            VerstInitM.Text = VerstInitM.Text.Replace(".", ",");
            MontantRachatM.Text = MontantRachatM.Text.Replace(".", ",");
            VerstCompM.Text = VerstCompM.Text.Replace(".", ",");
            RachatPrecM.Text = RachatPrecM.Text.Replace(".", ",");
            MontantEncoursM.Text = MontantEncoursM.Text.Replace(".", ",");


            //Affectation des Valeurs Collectées*************************
            string DateTimeValueM=DateSousM.Text;
            double ValoContratValueM=double.Parse(ValoContratM.Text);
            double VerstInitValueM= double.Parse(VerstInitM.Text);
            double VerstCompValueM = double.Parse(VerstCompM.Text);
            double RachatPrecValueM=double.Parse (RachatPrecM.Text);
            double MontantRachatValueM = double.Parse(MontantRachatM.Text);
            double MontantEncoursValueM = double.Parse(MontantEncoursM.Text);

            string StatutValueM = StatutMatM.Text;
            int TMIValueM = int.Parse(ComboboxTMIM.Text);
            int Abattement = 0;

            //Formatage des valeurs Collectées dans les TextBox***********
            ValoContratM.Text = string.Format("{0:n}", ValoContratValueM);
            VerstInitM.Text = string.Format("{0:n}", VerstInitValueM);
            MontantRachatM.Text = string.Format("{0:n}", MontantRachatValueM);
            VerstCompM.Text = string.Format("{0:n}", VerstCompValueM);
            RachatPrecM.Text = string.Format("{0:n}", RachatPrecValueM);
            MontantEncoursM.Text = string.Format("{0:n}", MontantEncoursValueM);

            //Calcul de l'âge du contrat***********************************
            DateTime DateFinM= DateTime.Now;
            DateTime DateDebutM=DateTime.Parse(DateSousM.Text); 
            TimeSpan IntervalleValueM= DateFinM- DateDebutM;
            Double DureeAnneeValueM = (IntervalleValueM.Days / 365);


            //calcul de l'Abattement****************************************
            if(DureeAnneeValueM>=8)
            {
                if(StatutValueM=="Marié(e)" || StatutValueM == "Pacsé(e)") 
                {
                    Abattement = 9200;

                }
                else 
                {
                    Abattement = 4600;
                
                }

            }
            else 
            {
                Abattement = 0;
            }

            // Détermination de la Plus-Value*********************************
            double SommesTotalesValueM=VerstInitValueM+VerstCompValueM;
            double BaseValueM = SommesTotalesValueM - RachatPrecValueM;
            double PlusValueM = MontantRachatValueM - ((BaseValueM * MontantRachatValueM) / ValoContratValueM);
            

            // Après Abattement************************************************
            double PlusValueNetteM = PlusValueM - Abattement;
            


            //Condition pour exclure une plus-value Nette NEGATIVE*************
            if( PlusValueNetteM < 0) 
            {
            PlusValueNetteM=0;
            }


            //1-Calcul des Traitements Fiscaux********************************
            //a- Taux de Prélèvement

            if(DureeAnneeValueM<8) 
            {
                double TauxPLFM = 12.80;
                double PrelevementValueM = PlusValueNetteM * (TauxPLFM / 100);
                TauxPrelevtLibM.Text=TauxPLFM.ToString();
                MontantPrelevtM.Text=PrelevementValueM.ToString("0.00");

             }

            else if (DureeAnneeValueM >= 8) 
            {
                if (MontantEncoursValueM < 150000) 
                {
                    double TauxPLFM = 7.5;
                    double PrelevementValueM= PlusValueNetteM * (TauxPLFM/100);
                    MontantPrelevtM.Text = PrelevementValueM.ToString("0.00");
                }
                else 
                {

                    MessageBox.Show("Abattements de 4600€ ou 9200€ puis 12.80% sur les produits attachés à la part des primes >150 000€");
                }

                

            }
            // Bareme de l'IRPP**********************************************************
            double ImpotProgValueM = (PlusValueNetteM * TMIValueM) / 100;

            //Prélèvements Sociaux*****************************************************
            double PrelevementsSociauxValueM = PlusValueNetteM * 0.1720;


            //Affichage des resultats*************************************************
            PlusValueBruteM.Text = PlusValueM.ToString("0.00");
            PlusValueNetteRM.Text = PlusValueNetteM.ToString("0.00");
            IRPPMargM.Text = ImpotProgValueM.ToString("0.00");
            PrelevtSociauxM.Text = PrelevementsSociauxValueM.ToString("0.00");

        }

        private void Commentaire_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            
        }

        // Fermeture de la fenetre**************************************
        private void Btn_Sortie_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            ValoContratM.Text = string.Empty;
            VerstInitM.Text = string.Empty;
            MontantRachatM.Text = string.Empty;
            VerstCompM.Text = string.Empty;
            RachatPrecM.Text = string.Empty ;
            MontantEncoursM.Text = string.Empty;
            PlusValueBruteM.Text=string.Empty;
            PlusValueNetteRM.Text=string.Empty;
            IRPPMargM.Text=string.Empty;
            TauxPrelevtLibM.Text=string.Empty;
            MontantPrelevtM.Text=string.Empty;
            PrelevtSociauxM.Text=string.Empty;
            DateSousM.Text=string.Empty;
        }
    }
}
