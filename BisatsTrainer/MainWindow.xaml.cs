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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BisatsTrainer;

namespace BisatsTrainer
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

        private void startTraining_Click(object sender, RoutedEventArgs e)
        {
            Sentencer.SetText(textBox.Text.ToLower());
            Sentencer.Sentencing();
            SentenceWindow sentencesDissordered = new SentenceWindow();
            sentencesDissordered.Show();
            this.Close();
        }

        private void uploadFile_Click(object sender, RoutedEventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
