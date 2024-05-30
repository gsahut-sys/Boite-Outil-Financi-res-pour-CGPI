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
    /// Logique d'interaction pour FiscaliteDcAV.xaml
    /// </summary>
    public partial class FiscaliteDcAV : Window
    {
        public FiscaliteDcAV()
        {
            InitializeComponent();
            
        }
       


        private void Btn_Calculs_Click(object sender, RoutedEventArgs e)
        {
            //Traitement de la Virgule
            ValoContrat.Text = ValoContrat.Text.Replace(".", ",");
            PartCJ.Text = PartCJ.Text.Replace(".", ",");
            VerstAvant98.Text = VerstAvant98.Text.Replace(".", ",");
            VerstApres98.Text = VerstApres98.Text.Replace(".", ",");
            PrimeAp70.Text = PrimeAp70.Text.Replace(".", ",");
            PrimeAv70.Text = PrimeAv70.Text.Replace(".", ",");
         

            //Affectation des Valeurs Collectées
            string DateTimeValueDC = DateSous.Text;
            DateTime Date = DateTime.Parse(DateSous.Text);
            double ValoContratValueDC = double.Parse(ValoContrat.Text);
            double PartCJValueDC = double.Parse(PartCJ.Text);
            double VerstAvant98ValueDC = double.Parse(VerstAvant98.Text);
            double VerstApres98ValueDC = double.Parse(VerstApres98.Text);
            double PrimeAp70ValueDC = double.Parse(PrimeAp70.Text);
            double PrimeAv70ValueDC = double.Parse(PrimeAv70.Text);
            double NbBenefValueDC = double.Parse(NbBenef.Text);
          
            

            //Formatage des Valerurs Collectées
            ValoContrat.Text = string.Format("{0:n}", ValoContratValueDC);
            PartCJ.Text = string.Format("{0:n}", PartCJValueDC);
            VerstAvant98.Text = string.Format("{0:n}", VerstAvant98ValueDC);
            VerstApres98.Text = string.Format("{0:n}", VerstApres98ValueDC);
            PrimeAp70.Text = string.Format("{0:n}", PrimeAp70ValueDC);
            PrimeAv70.Text = string.Format("{0:n}", PrimeAv70ValueDC);
          

            //Declaration de Variables
            double HeritageValueDC = (152500 * NbBenefValueDC);
            //double DroitContratValue = 0;
            double ExonerationValueDC = 0;
            double Cumul990i = 0;
            double Cumul757b = 0;
            double DroitsContrat990i20 = 0;
            double DroitsContrat990i3125 = 0;
            double Base20Pourc = 0;
            double Prelevt20Pourc = 0;
            double Base3125Pourc = 0;
            double Prelevt3125Pourc = 0;
            double Cumul757bNet = 0;



            //Test sur la date de souscription
            DateTime Date1 = new DateTime(1991, 11, 20);

            //MessageBox.Show("Date de Souscription : " + Date);
            //MessageBox.Show("Date de Référence : " + Date1);
            //MessageBox.Show("Valorisation des abattements :" + HeritageValueDC);


            //Avant91
            if (Date1.Date > Date.Date && VerstAvant98ValueDC > 0)

            {
                //MessageBox.Show("Le contrat a été souscrit avant 91 avec verst avant 98");
                ExonerationValueDC += ValoContratValueDC;
                //MessageBox.Show("Exoneration : " + ExonerationValueDC);

            }
            if (Date1.Date > Date.Date && VerstApres98ValueDC > 0)
            {

                //MessageBox.Show("Le Contrat a été souscrit avant 91 avec verst apres 98");
                //MessageBox.Show("Traitement en 990i");


                //Message sur test des 700 000€***sans calculs***
                if ((ValoContratValueDC - HeritageValueDC - PartCJValueDC) > 700000)
                {
                    MessageBox.Show("La somme totale des contrats, après abattements, est supérieure à 700 000 €, le taux de 31.25% est suceptible d'être appliqué");
                }
                if ((ValoContratValueDC - HeritageValueDC - PartCJValueDC) <= 700000)
                {
                    MessageBox.Show("La somme totale des contrats, après abattements, est inférieure à 700 000 €, le taux de 20% est appliqué");

                }


                // Si la totalité des abattements couvre le contrat

                if ((ValoContratValueDC - PartCJValueDC) <= HeritageValueDC)
                {
                    ExonerationValueDC += ValoContratValueDC;
                    //MessageBox.Show("la somme des abattement est supérieure au contrat");
                    //MessageBox.Show("Heritage : " + HeritageValueDC);
                    //MessageBox.Show("l'exoneration est totale sur la valeur du contrat");
                }

                if ((ValoContratValueDC - PartCJValueDC) > HeritageValueDC)
                {


                    if ((ValoContratValueDC - HeritageValueDC - PartCJValueDC) <= 700000)
                    {
                        Base20Pourc = (ValoContratValueDC - HeritageValueDC - PartCJValueDC);
                        Prelevt20Pourc = Base20Pourc * 0.20;
                        Cumul990i += (ValoContratValueDC - Prelevt20Pourc);
                        //MessageBox.Show("base 20 %:" + Base20Pourc);
                        //MessageBox.Show("Prelevement de 20% :" + Prelevt20Pourc);
                        //MessageBox.Show("Cumul 900 i :" + Cumul990i);
                    }


                    if ((ValoContratValueDC - HeritageValueDC - PartCJValueDC) > 700000)

                    {

                        Base3125Pourc = (ValoContratValueDC - HeritageValueDC - PartCJValueDC - 700000);
                        Prelevt3125Pourc = Base3125Pourc * 0.3125;
                        Base20Pourc = (ValoContratValueDC - HeritageValueDC - PartCJValueDC - Base3125Pourc);
                        Prelevt20Pourc = Base20Pourc * 0.20;
                        Cumul990i += (ValoContratValueDC - Prelevt20Pourc - PartCJValueDC - Prelevt3125Pourc);
                        //MessageBox.Show("base 20 %:" + Base20Pourc);
                        //MessageBox.Show("Prelevement de 20% :" + Prelevt20Pourc);
                        //MessageBox.Show("base 3125 %:" + Base3125Pourc);
                        //MessageBox.Show("Prelevement de 3125% :" + Prelevt3125Pourc);
                        //MessageBox.Show("Cumul 900 i :" + Cumul990i);

                    }

                }


            }
            //Apres 91
            if (Date1.Date < Date.Date)
            {
                //MessageBox.Show("Le Contrat a été souscrit après 91");
              

                if (PrimeAp70ValueDC > 0)
                    //757b
                {
                    
                    Cumul757b = PrimeAp70ValueDC;
                    //MessageBox.Show("Sommes à déclarer au titre de l'article 757B après abattement global de 30 500€ : " + Cumul757b);
                    //MessageBox.Show("Les Bénéficiaires se partagent le contrat : " + ValoContratValueDC);
                   
                }
                if (PrimeAv70ValueDC > 0 && VerstAvant98ValueDC>0)
                //exo
                {
                    //MessageBox.Show("Versement avant 70 ans");
                    //MessageBox.Show("Primes Exonérées ! :" + PrimeAv70ValueDC);
                    //MessageBox.Show("Contrat Exonéré :" + ValoContratValueDC);
                    ExonerationValueDC += ValoContratValueDC;
                }

                if (PrimeAv70ValueDC > 0 && VerstApres98ValueDC > 0) 
                //990 i
                {

                   //MessageBox.Show("Traitement 990i");
                    //Message sur test des 700 000€***sans calculs***
                    if ((ValoContratValueDC - HeritageValueDC - PartCJValueDC) > 700000)
                    {
                        MessageBox.Show("La somme totale des contrats, après abattements, est supérieure à 700 000 €, le taux de 31.25% est suceptible d'être appliqué");
                    }
                    if ((ValoContratValueDC - HeritageValueDC - PartCJValueDC) <= 700000)
                    {
                        MessageBox.Show("La somme totale des contrats, après abattements, est inférieure à 700 000 €, le taux de 20% est appliqué");
                    }

                        // Si la totalité des abattements couvre le contrat

                    if ((ValoContratValueDC - PartCJValueDC) <= HeritageValueDC)
                        {
                            ExonerationValueDC += ValoContratValueDC;
                            //MessageBox.Show("la somme des abattement est supérieure au contrat");
                            //MessageBox.Show("Heritage : " + HeritageValueDC);
                            //MessageBox.Show("l'exoneration est totale sur la valeur du contrat");
                        }

                    if ((ValoContratValueDC - PartCJValueDC) > HeritageValueDC)
                    {


                            if ((ValoContratValueDC - HeritageValueDC - PartCJValueDC) <= 700000)
                            {
                                Base20Pourc = (ValoContratValueDC - HeritageValueDC - PartCJValueDC);
                                Prelevt20Pourc = Base20Pourc * 0.20;
                                Cumul990i += (ValoContratValueDC - Prelevt20Pourc);
                                //MessageBox.Show("base 20 %:" + Base20Pourc);
                                //MessageBox.Show("Prelevement de 20% :" + Prelevt20Pourc);
                                //MessageBox.Show("Cumul 900 i :" + Cumul990i);
                            }


                            if ((ValoContratValueDC - HeritageValueDC - PartCJValueDC) > 700000)

                            {

                                Base3125Pourc = (ValoContratValueDC - HeritageValueDC - PartCJValueDC - 700000);
                                Prelevt3125Pourc = Base3125Pourc * 0.3125;
                                Base20Pourc = (ValoContratValueDC - HeritageValueDC - PartCJValueDC - Base3125Pourc);
                                Prelevt20Pourc = Base20Pourc * 0.20;
                                Cumul990i += (ValoContratValueDC - Prelevt20Pourc - Prelevt3125Pourc);
                                //MessageBox.Show("base 20 %:" + Base20Pourc);
                                //MessageBox.Show("Prelevement de 20% :" + Prelevt20Pourc);
                                //MessageBox.Show("base 3125 %:" + Base3125Pourc);
                                //MessageBox.Show("Prelevement de 3125% :" + Prelevt3125Pourc);
                                //MessageBox.Show("Cumul 900 i :" + Cumul990i);
                            }


                        

                    }
            


                }

            }

            //Attribution des données
            

            Exo.Text = ExonerationValueDC.ToString("0.00");
            ExoCJ.Text = PartCJValueDC.ToString("0.00");

            Part20pourcent.Text = Base20Pourc.ToString("0.00");
            Part3125pourcent.Text = Base3125Pourc.ToString("0.00");
            DroitsContrat990i20 = Base20Pourc * 0.20;
            DroitsContrat990i3125 = Base3125Pourc * 0.3125;
            Part20Euros.Text = DroitsContrat990i20.ToString("0.00");
            Part3125Euros.Text = DroitsContrat990i3125.ToString("0.00");

            Cumul757bNet = Cumul757b - 30500;
            //MessageBox.Show("Cumul757b apres 30500: " + Cumul757bNet);
            if (Cumul757bNet > 0) 
            { Cumul757bR.Text = Cumul757bNet.ToString("0.00"); }
            
            if (Cumul757bNet<=0)
            {
             Cumul757bNet = 0;
             Cumul757bR.Text = Cumul757bNet.ToString("0.00");
            }

            Exo.Text = string.Format("{0:n}", ExonerationValueDC);
            ExoCJ.Text = string.Format("{0:n}", PartCJValueDC);
            Part20pourcent.Text = string.Format("{0:n}", Base20Pourc);
            Part3125pourcent.Text = string.Format("{0:n}", Base3125Pourc);
            Part20Euros.Text = string.Format("{0:n}", DroitsContrat990i20);
            Part3125Euros.Text = string.Format("{0:n}", DroitsContrat990i3125);
            Cumul757bR.Text = string.Format("{0:n}", Cumul757bNet);




        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Btn_AutreCalculs_Click(object sender, RoutedEventArgs e)
        {
            
            DateSous.Text=String.Empty;
            ValoContrat.Text=String.Empty;
            PartCJ.Text=String.Empty;
            NbBenef.Text=String.Empty;
            VerstAvant98.Text=String.Empty;
            VerstApres98.Text=String.Empty;
            PrimeAv70.Text=String.Empty;
            PrimeAp70.Text=String.Empty;
            Exo.Text=String.Empty;
            ExoCJ.Text = String.Empty;
            Part20pourcent.Text=String.Empty;
            Part20Euros.Text=String.Empty;
            Part3125pourcent.Text = String.Empty;
            Part3125Euros.Text = String.Empty;
            Cumul757bR.Text=String.Empty;


        }
      
   
    
    }
}
    




           