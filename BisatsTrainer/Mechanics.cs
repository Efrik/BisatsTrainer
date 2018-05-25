using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisatsTrainer
{
    static class Sentencer
    {
        public static List<Sentence> sentences = new List<Sentence>();
        private static string txt = "";
        private static int currentSent = 0;

        public static void Sentencing ()
        {
            StringBuilder sentBuilder = new StringBuilder();
            int lastChar = 0;
            
            for (int i=0; i <txt.Length; i++)
            {
                char txtChar = txt.ElementAt(i);
                
                if (txtChar.Equals('.')||txtChar.Equals('\0'))
                {
                    sentBuilder.Insert(sentBuilder.Length, ' ');
                    string sentString = sentBuilder.ToString();
                    Sentence sentSent = new Sentence(sentString);
                    sentences.Add(sentSent);
                    sentBuilder.Clear();
                    lastChar = i + 1;
                }
                else
                {
                    sentBuilder.Insert(i-lastChar, txtChar);
                }
            }
            if (sentBuilder.Equals("")) { } else
            {
                string sentString = sentBuilder.ToString();
                sentBuilder.Clear();
                Sentence sentSent = new Sentence(sentString);
                sentences.Add(sentSent);
            }
        }
        
        public static int GetCurrentSent()
        {
            return currentSent;
        }

        public static void NextSent()
        {
            if (currentSent == sentences.Count -1) currentSent=0;
            else currentSent+= 1;
        }

        public static Sentence GetSentence (int number)
        {
            Sentence sent = sentences.ElementAt(number);
            return sent;
        }

        public static void SetText(string str)
        {
            txt = str;
            Console.WriteLine("this is the text" + txt);
        }
    }

    class Sentence
    {
        private string sentence = "";
        List<string> words = new List<string>();
        private List<string> randomized = new List<string>();

        public Sentence(string sent)
        {
            sentence = sent;
            Worder();
        }

        public void Worder ()
        { 
            StringBuilder wordBuild = new StringBuilder();
            string wordString = "";
            int lastI = 0;
            for (int i = 0; i < sentence.Length; i++)
            {
                if (sentence.ElementAt(i).Equals(' '))
                {
                    lastI = i+1;
                    wordBuild.Insert(wordBuild.Length, " ");
                    wordString = wordBuild.ToString();
                    words.Add(wordString);
                    wordBuild.Clear();
                }
                else
                {
                    wordBuild.Insert(i-lastI, sentence.ElementAt(i));
                }
            }
        }

        public void Randomize()
        {
            Random rnd = new Random();
            int number = words.Count;
            randomized.Clear();

            while (words.Count > 0)
            {
                number = rnd.Next(words.Count);
                randomized.Add(words.ElementAt(number));
                words.RemoveAt(number);
            }
            Worder();
        }

        public string GetSentence()
        {
            return sentence;
        }

        public List<string> GetRndWords ()
        {
            Randomize();
            return randomized;
        }
    }

    static class Methods
    {

    }
}
