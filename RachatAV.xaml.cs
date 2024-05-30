using System;
using System.Collections.Generic;
using System.Data;
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
    /// Logique d'interaction pour RachatAV.xaml
    /// </summary>
    public partial class RachatAV : Window
    {
        public RachatAV()
        {
            InitializeComponent();
         
                    
                      

        }

        private void Btn_Calcul_Click(object sender, RoutedEventArgs e)
        {
            //traitement de la virgule ************************************
            ValoContrat.Text = ValoContrat.Text.Replace(".", ",");
            VerstInit.Text = VerstInit.Text.Replace(".", ",");
            VerstComp.Text = VerstComp.Text.Replace(".", ",");
            RachatPrec.Text = RachatPrec.Text.Replace(".", ",");
            MontantRachat.Text = MontantRachat.Text.Replace(".", ",");




            //Affectation des Valeurs collectées
            string DateTimeValue = DateSous.Text;
            double ValoContratValue = double.Parse(ValoContrat.Text);
            double VerstInitValue = double.Parse(VerstInit.Text);
            double VerstCompValue = double.Parse(VerstComp.Text);
            double RachatPrecValue = double.Parse(RachatPrec.Text);
            double MontantRachatValue = double.Parse(MontantRachat.Text);
            string StatutValue = StatutMat.Text;
            int TMIValue = int.Parse(ComboboxTMI.Text);
            int Abattement = 0;
            //MessageBox.Show("Statut Marital :" + StatutValue);
            //MessageBox.Show("TMI Estimée :" + TMIValue);
            


            //**************************************************************

            // Formatage des valeurs collectées dans les TextBox
            ValoContrat.Text = String.Format("{0:n}", ValoContratValue);
            VerstInit.Text = String.Format("{0:n}", VerstInitValue);
            VerstComp.Text = String.Format("{0:n}", VerstCompValue);
            RachatPrec.Text = String.Format("{0:n}", RachatPrecValue);
            MontantRachat.Text = String.Format("{0:n}", MontantRachatValue);

            //***************************************************************

            //Calcul de l'âge du Contrat : DureeAnneeValue
            DateTime DateFin = DateTime.Now;
            DateTime DateDebut = DateTime.Parse(DateSous.Text);
            TimeSpan IntervalleValue = DateFin - DateDebut;
            double DureeAnneeValue = (IntervalleValue.Days / 365);
            //MessageBox.Show("Age du Contrat :" + DureeAnneeValue);


            //***************************************************************
            //Calcul de l'abattement 
            if (DureeAnneeValue >= 8)
            {
                if (StatutValue == "Marié(e)" || StatutValue == "Pacsé(e)")
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
            //MessageBox.Show("Montant de l'Abattement :" + Abattement);

            //******************************************************************

            //Détermination de la plus-value  ****PlusValue et PlusValueNette***
            double SommesTotalesValue = VerstInitValue + VerstCompValue;
            double BaseValue= SommesTotalesValue-RachatPrecValue;
            double PlusValue=MontantRachatValue-((BaseValue * MontantRachatValue)/ValoContratValue);
            //MessageBox.Show("Plus Value Avant Abattement :" + PlusValue);

            //après abattement
            double PlusValueNette= PlusValue-Abattement;
            //MessageBox.Show("Plus Value après Abattement :" + PlusValueNette);


            //une plus value nette ne peut pas être négative
            if (PlusValueNette < 0) 
            { 
                PlusValueNette = 0; 
            }
            //MessageBox.Show("Plus Value après Abattement :" + PlusValueNette);

            //********************************************************************


            //1-Calculs des traitements fiscaux
            // a-Taux de Prélèvement ****PrelevementValue****
            if (DureeAnneeValue<4) 
            {
                double TauxPLF = 35;
                Double PrelevementValue = (PlusValueNette * TauxPLF/100);
                //MessageBox.Show("Montant du Prélèvement :" + PrelevementValue);
                TauxPrelevtLib.Text = TauxPLF.ToString();
                MontantPrelevt.Text = PrelevementValue.ToString("0.00");
            } 
            else if (DureeAnneeValue>=4 &&DureeAnneeValue<8)
            {
                double TauxPLF = 15;
                Double PrelevementValue = (PlusValueNette * TauxPLF)/100;
                //MessageBox.Show("Montant du Prélèvement :" + PrelevementValue);
                TauxPrelevtLib.Text = TauxPLF.ToString();
                MontantPrelevt.Text = PrelevementValue.ToString("0.00");
            }
            else if (DureeAnneeValue>=8)
            {
                double TauxPLF = 7.5;
                Double PrelevementValue = (PlusValueNette * TauxPLF)/100;
                //MessageBox.Show("Montant du Prélèvement :" + PrelevementValue);
                TauxPrelevtLib.Text = TauxPLF.ToString();
                MontantPrelevt.Text = PrelevementValue.ToString("0.00");
            }

            

            // b-Bareme de l'IRPP ****impotProgValue****
            double ImpotProgValue= (PlusValueNette*TMIValue)/100;
            //MessageBox.Show("Montant de l'Impôt sur le Revenu Estimé :" + ImpotProgValue);

            //Prélèvement Sociaux*******************************************
            double PrevlementSociauxValue = PlusValueNette * 0.1720;


            //Affichage des resultats***************************************
            PlusValueBrute.Text = PlusValue.ToString("0.00");
            PlusValueNetteR.Text= PlusValueNette.ToString("0.00");
            IRPPMarg.Text=ImpotProgValue.ToString("0.00");
            PrelevtSociaux.Text = PrevlementSociauxValue.ToString("0.00");





        }
        //Fermeture de la fenêtre************************************
        private void Btn_Sortie_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Autre Calcul**************************************************
        private void Btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            DateSous.Text = string.Empty;
            ValoContrat.Text = string.Empty;
            VerstInit.Text = string.Empty;
            MontantRachat.Text = string.Empty;
            VerstComp.Text = "0";
            RachatPrec.Text = "0";
            PlusValueBrute.Text= string.Empty;
            PlusValueNetteR.Text= string.Empty;
            IRPPMarg.Text = string.Empty;
            TauxPrelevtLib.Text = string.Empty;
            MontantPrelevt.Text = string.Empty;


        }
    }
}
