using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DailyChallenge240
{
    class Program
    {
        

        static void Main()
        {
            string input;
            do {
                Console.WriteLine(Convert("According to a research team at Cambridge University, it doesn't matter in what order "+
                    "the letters in a word are, the only important thing is that the first and last letter be in the right place. " +
                    "The rest can be a total mess and you can still read it without a problem. This is because the human mind does " +
                    "not read every letter by itself, but the word as a whole."));
                Console.WriteLine();
                Console.WriteLine("Press any key to continue, or type 'x' to exit");
                input = Console.ReadLine();
            } while (input != "x");            
        }

        static string Convert(string text)
        {            
            var tList = text.Split(' ');
            var sb = new StringBuilder();

            foreach (var w in tList) {
                sb.Append(Shuffle(w));
                sb.Append(" ");
            }

            return sb.ToString();            
        }

        static string Shuffle(string inputWord)
        {
            if (inputWord.Length < 4) 
                return inputWord;

            var rand = new Random();
            var midOriginal = inputWord.Substring(1, inputWord.Length - 2);
            bool addNonAlphaToEnd = false;

            char firstChar = inputWord[0];
            char lastChar = inputWord[inputWord.Length - 1];
            char lastCharTemp = ' ';
            string mid = midOriginal;
                        
            if (!char.IsLetter(lastChar))   // check if last character of a word is not a letter.
            {
                addNonAlphaToEnd = true;
                lastCharTemp = lastChar;
                mid = inputWord.Substring(1, inputWord.Length - 3);
                lastChar = inputWord[inputWord.Length - 2];
            }

            string scrambledMid;
            do {
                var midChars = mid.ToList();
                scrambledMid = "";

                while (midChars.Count > 0)
                {
                    int i = rand.Next(midChars.Count);
                    scrambledMid += midChars[i];
                    midChars.RemoveAt(i);
                }     
            } while (scrambledMid == midOriginal);     // loop until the word is scrambled (i.e. not the original word)

            if (addNonAlphaToEnd)
                return firstChar + scrambledMid + lastChar + lastCharTemp;

            return firstChar + scrambledMid + lastChar;
        }
    }
}
