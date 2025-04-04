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

            List<Buch> buecher_inventar = new List<Buch>() {
            new Buch() { Titel = "Vom Winde verweht", Author = "Hans Mueller"},
            new Buch() { Titel = "Vom Sturm verweht", Author = "Hans Mueller"},
            new Buch() { Titel = "Der Herr der Ringe", Author = "J.R.R. Tolkien" },
            new Buch() { Titel = "Stolz und Vorurteil", Author = "Jane Austen" },
            new Buch() { Titel = "1984", Author = "George Orwell" },
            new Buch() { Titel = "Die Verwandlung", Author = "Franz Kafka" },
            new Buch() { Titel = "Faust", Author = "Johann Wolfgang von Goethe" },
            new Buch() { Titel = "Harry Potter und der Stein der Weisen", Author = "J.K. Rowling" },
            new Buch() { Titel = "Der Schatten des Windes", Author = "Carlos Ruiz Zafón" },
            new Buch() { Titel = "Der Alchimist", Author = "Paulo Coelho" },
            new Buch() { Titel = "Das Parfum", Author = "Patrick Süskind" },
            new Buch() { Titel = "Krieg und Frieden", Author = "Leo Tolstoi" },
            new Buch() { Titel = "Der Fänger im Roggen", Author = "J.D. Salinger" },
            new Buch() { Titel = "Die unendliche Geschichte", Author = "Michael Ende" },
            new Buch() { Titel = "Moby Dick", Author = "Herman Melville" },
            new Buch() { Titel = "Der kleine Prinz", Author = "Antoine de Saint-Exupéry" },
            new Buch() { Titel = "Die Säulen der Erde", Author = "Ken Follett" },
            new Buch() { Titel = "Sakrileg", Author = "Dan Brown" },
            new Buch() { Titel = "Per Anhalter durch die Galaxis", Author = "Douglas Adams" },
            new Buch() { Titel = "Der Medicus", Author = "Noah Gordon" },
            new Buch() { Titel = "Wer die Nachtigall stört", Author = "Harper Lee" },
            new Buch() { Titel = "Der Name der Rose", Author = "Umberto Eco" }
            };
            //Console.WriteLine(buecher[1].Author);

            /*
            buecher_inventar = buecher_inventar.OrderBy(Buch => Buch.Titel).ToList();

            foreach (var item in buecher_inventar)
            {
                Console.WriteLine(item.Titel);
            }
            */
            do
            {
                #region Menue

                Console.WriteLine($"Bibliotheke");
                Console.WriteLine($"==================================================");
                Console.WriteLine($"1) Bücher ansehen");
                Console.WriteLine($"2) Bücher anfuegen");
                Console.WriteLine($"3) Bücher ausleihen");
                Console.WriteLine($"4) Bücher zurueckgeben");
                Console.WriteLine($"5) Ausgeliehende Buecher ausgeben");
                Console.WriteLine($"6) Buecher entfernen");
                Console.WriteLine();
                Console.WriteLine($"x) Ende");
                Console.WriteLine($"==================================================");
                Console.WriteLine();
                #endregion Menue

                Console.Write("Ihre Auswahl: ");

                string Auswahl = Console.ReadLine();
                Auswahl = Auswahl.ToLower();
                switch (Auswahl)
                {
                    #region Buech ansehen
                    case "1":

                        break;
                    #endregion
                    #region Buch hinzufuegen
                    case "2":
                        break;
                    #endregion
                    #region Buech ausleihen
                    case "3":
                        break;
                    #endregion
                    #region Buech zurueckgeben
                    case "4":
                        break;
                    #endregion
                    #region Ausgeliehende Bücher ausgeben
                    case "5":
                        break;
                    #endregion
                    #region Buecher entfernen
                    case "6":
                        break;
                    #endregion
                    #region Programm beenden
                    case "x":
                        break;
                    #endregion
                    default:
                        Console.WriteLine($"");
                        Console.WriteLine("Eingabe Fehlerhaft");
                        Console.WriteLine("Bitte wiederholen Sie ihre Eingabe.");
                        break;
                };
                Console.WriteLine();
                Console.WriteLine("Drücken Sie eine beliebige Taste um fortzufahren ...");
                Console.ReadKey();
                Console.Clear();
            } while (true);
        }
    }
}
