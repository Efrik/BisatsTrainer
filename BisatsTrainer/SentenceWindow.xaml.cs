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

namespace BisatsTrainer
{
    /// <summary>
    /// Interaction logic for SentenceWindow.xaml
    /// </summary>
    public partial class SentenceWindow : Window
    {
        public SentenceWindow()
        {
            InitializeComponent();
        }

        private void showButton_Click(object sender, RoutedEventArgs e)
        {
            if (sentenceLabel.Content== "Press the Show button to see the sentence")
            {
                int current = Sentencer.GetCurrentSent();
                sentenceLabel.Content = Sentencer.GetSentence(current).GetSentence(); 
            } else
            {
                sentenceLabel.Content = "Press the Show button to see the sentence";
            }
        }

        private void wordsBox_Initialized(object sender, EventArgs e)
        {
            wordsBox_update();
        }

        private void wordsBox_update ()
        {
            List<string> words = Sentencer.GetSentence(Sentencer.GetCurrentSent()).GetRndWords();
            wordsBox.Text = "";
            for (int i = 0; i < words.Count; i++)
            {
                wordsBox.Text += words.ElementAt(i).ToString();
            }
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            Sentencer.NextSent();
            sentenceLabel.Content = "Press the Show button to see the sentence";
            wordsBox_update();
        }
    }
}
