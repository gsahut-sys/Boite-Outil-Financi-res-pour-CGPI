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
    /// Logique d'interaction pour PensionsE.xaml
    /// </summary>
    public partial class PensionsE : Window
    {
        public PensionsE()
        {
            InitializeComponent();
            int AnneeRefValue = (DateTime.Now.Year) - 2;
            AnneeRef.Text = AnneeRefValue.ToString();
            //AnneeRef.Text=DateTime.Now.Year.ToString();
        }

        private void Btn_Calcul_Click(object sender, RoutedEventArgs e)
        {
            //Traitement de la Virgule
            RFR.Text = RFR.Text.Replace(".", ",");
            Pension1.Text = Pension1.Text.Replace(".", ",");
            Pension2.Text = Pension2.Text.Replace(".", ",");

            //Affectation des Valeurs
            double RFRValue=double.Parse(RFR.Text);
            double Pension1Value=double.Parse(Pension1.Text);
            double Pension2Value=double.Parse(Pension2.Text);
            double QFValue= double.Parse(ComboQF.Text);

          
            
            double TauxPS = 0;
            double CsgDeductible = 0;
            


            //Formatage des Valeus Collectées
            RFR.Text = String.Format("{0:n}", RFRValue);
            Pension1.Text = String.Format("{0:n}", Pension1Value);
            Pension2.Text = String.Format("{0:n}", Pension2Value);

            //Calculs du taux des
            if (QFValue == 1) 
            {
                if (RFRValue < 12230) { TauxPS = 0; }
                if (RFRValue > 12230 && RFRValue <15988) { TauxPS = 0.043; CsgDeductible = 0.038; }
                if (RFRValue > 15989 && RFRValue < 24813) { TauxPS = 0.074; CsgDeductible = 0.042; }
                if (RFRValue > 24813) { TauxPS = 0.091; CsgDeductible = 0.059; }
             }

            if (QFValue == 1.5)
            {
                if (RFRValue < 15495) { TauxPS = 0; }
                if (RFRValue > 15496 && RFRValue < 20257) { TauxPS = 0.043; CsgDeductible = 0.038; }
                if (RFRValue > 20258 && RFRValue < 31436) { TauxPS = 0.074; CsgDeductible = 0.042; }
                if (RFRValue > 31436) { TauxPS = 0.091; CsgDeductible = 0.059; }
            }
            if (QFValue == 2)
            {
                if (RFRValue < 18760) { TauxPS = 0; }
                if (RFRValue > 18761 && RFRValue < 24526) { TauxPS = 0.043; CsgDeductible = 0.038; }
                if (RFRValue >  24527 && RFRValue < 38059) { TauxPS = 0.074; CsgDeductible = 0.042; }
                if (RFRValue > 38059) { TauxPS = 0.091; CsgDeductible = 0.059; }
            }
            if (QFValue == 2.5)
            {
                if (RFRValue < 22025) { TauxPS = 0; }
                if (RFRValue > 22026 && RFRValue < 28796) { TauxPS = 0.043; CsgDeductible = 0.038; }
                if (RFRValue > 28796 && RFRValue < 44682) { TauxPS = 0.074; CsgDeductible = 0.042; }
                if (RFRValue > 44682) { TauxPS = 0.091; CsgDeductible = 0.059; }
            }
            if (QFValue == 3)
            {
                if (RFRValue < 25290) { TauxPS = 0; }
                if (RFRValue > 25291 && RFRValue < 33064) { TauxPS = 0.043; CsgDeductible = 0.038; }
                if (RFRValue > 33065 && RFRValue < 51305) { TauxPS = 0.074; CsgDeductible = 0.042; }
                if (RFRValue > 51305) { TauxPS = 0.091; CsgDeductible = 0.059; }
            }

            if (QFValue == 3.5)
            {
                if (RFRValue < 28555) { TauxPS = 0; }
                if (RFRValue > 28556 && RFRValue < 36329) { TauxPS = 0.043; CsgDeductible = 0.038; }
                if (RFRValue > 36329 && RFRValue < 57928) { TauxPS = 0.074; CsgDeductible = 0.042; }
                if (RFRValue > 57928) { TauxPS = 0.091; CsgDeductible = 0.059; }
            }


            double CSGPension1 = Pension1Value * TauxPS;
            double CSGDedPension1= Pension1Value * CsgDeductible;
            double CSGPension2 = Pension2Value * TauxPS;
            double CSGDedPension2 = Pension2Value * CsgDeductible;
            //MessageBox.Show("Votre Quotient Familial est de :" + QFValue);
            //MessageBox.Show("La CSG pour la Pension N° 1 est :" + CSGPension1);
            //MessageBox.Show("La CSG Déductible pour la Pension  N° 1 est :" + CSGDedPension1);
            //MessageBox.Show("La CSG pour la Pension N° 2 est :" + CSGPension2);
            //MessageBox.Show("La CSG Déductible pour la Pension  N° 2 est :" + CSGDedPension2);


            CSGDec1.Text=CSGPension1.ToString("0");
            CSGDec2.Text=CSGPension2.ToString("0");
            CSGDed1.Text = CSGDedPension1.ToString("0");
            CSGDed2.Text = CSGDedPension2.ToString("0");

            double MontantNetAMValue = Pension1Value - CSGDedPension1;
            double MontantNetBMValue= Pension2Value - CSGDedPension2;
            MontantNetAM.Text = MontantNetAMValue.ToString("0");
            MontantNetBM.Text = MontantNetBMValue.ToString("0");
            double TauxPSAff = TauxPS * 100;
            TauxCSGFoyer.Text=TauxPSAff.ToString("0.00");

            CSGDec1.Text = String.Format("{0:n}", CSGPension1);
            CSGDec2.Text = String.Format("{0:n}", CSGPension2);
            CSGDed1.Text = String.Format("{0:n}", CSGDedPension1);
            CSGDed2.Text = String.Format("{0:n}", CSGDedPension2);

            MontantNetAM.Text = String.Format("{0:n}", MontantNetAMValue);
            MontantNetBM.Text = String.Format("{0:n}", MontantNetBMValue);

        }

        private void ComboQF_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Btn_Sortie_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            RFR.Text = String.Empty;
            Pension1.Text=String.Empty;
            Pension2.Text=String.Empty; 
            AnneeRef.Text=String.Empty;
            CSGDec1.Text=String.Empty;
            CSGDec2.Text=String.Empty;
            CSGDed1.Text=String.Empty;
            CSGDed2.Text=String.Empty;
            MontantNetAM.Text=String.Empty;
            MontantNetBM.Text=String.Empty;


        }
    }
}
