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
    /// Logique d'interaction pour DispatchAV.xaml
    /// </summary>
    public partial class DispatchAV : Window
    {
        public DispatchAV()
        {
            InitializeComponent();
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RachatAV RachatAv1 = new RachatAV();
            this.Close();
            RachatAv1.Show();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RachatAP RachatAv2= new RachatAP();
            this.Close();
            RachatAv2.Show();

        }
    }
}
