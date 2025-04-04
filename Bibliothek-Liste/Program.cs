using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek_Liste
{
    class Buch
    {
        public string Titel { get; set; }
        public string Author { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Bibliothek";

            List<Buch> buecher = new List<Buch>() {
                new Buch() { Titel = "Vom Winde verweht", Author = "Hans Mueller"},
                new Buch() { Titel = "Vom Sturm verweht", Author = "Hans Mueller"}
            };

            do
            {
                #region Menue
                Console.WriteLine(buecher[1].Author);


                #endregion Menue
                Console.ReadLine();
            } while (true);
        }
    }
}
