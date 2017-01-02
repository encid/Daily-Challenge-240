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
            Console.WriteLine(Convert("According to a research team at Cambridge University, it doesn't matter in what order he letters in a word are, the only important thing is that the first and last letter be in the right place. The rest can be a total mess and you can still read it without a problem. This is because the human mind does not read every letter by itself, but the word as a whole."));
            //Console.WriteLine(Convert("fantastical"));
            Console.ReadKey();
            
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

        static string Shuffle(string w)
        {
            var rnd = new Random();

            if (w.Length < 4) {
                return w;
            }

            char f, l;
            string m, mid;
            var mOld = w.Substring(1, w.Length - 2);

            f = w[0];
            l = w[w.Length - 1];
            m = w.Substring(1, w.Length - 2);            

            char[] chars = new char[m.Length];
            var rand = new Random();

            int index = 0;

            
                while (m.Length > 0) {
                    var next = rand.Next(0, m.Length - 1);
                    chars[index] = m[next];
                    m = m.Substring(0, next) + m.Substring(next + 1);
                    ++index;
                }

                mid = new string(chars); 
            

            return f + mid + l;
        }
    }
}
