using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CryptoSoft
{
    class CryptoSoft
    {
        public static string key = "xor";    // a static key to crypt using XOR

        // share info with class's methodes

        public static string source;         
        public static string destination;

        static void Main(string[] args)
        {

            if (args.Length != 2) {   // check if number of arguments != to 2 (only source and target)
                Console.WriteLine("Check your command Syntax to match the following :\nCryptoSoft.exe 'Source_path' 'Target_Path'");
            }
            else { 
                source = args[0];       // first argument goes for source path
                destination = args[1]; // second argument goes for target path

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                Crypt(source, key);
                stopwatch.Stop();

                // display time in ms with 2 decimals after dot
                Console.WriteLine("Done, Time elapsed: {0}", String.Format("{0:0.00}", stopwatch.Elapsed.TotalMilliseconds) + " ms");
            }
           

        }

        public static void Crypt(string source, string key)     // crypt and decrypt XOR methode
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < source.Length; i++)
                sb.Append((char)(source[i] ^ key[(i % key.Length)]));
            String result = sb.ToString();

            Results(destination, result);   // call Results methode to save results
        }

        public static void Results(string destination, string result)   // save results
        {
            File.AppendAllText(destination, result);
        }

    }
}
