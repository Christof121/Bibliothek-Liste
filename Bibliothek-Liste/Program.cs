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

            string uiBookAddTitel = "";
            string uiBookAddAuthor = "";
            string uiConfirmBookAdd = "";

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
            List<Buch> buecher_ausgeliehen = new List<Buch>();

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
                    
                    case "1": //Buecher ansehen
                        Console.Clear();
                        Console.WriteLine("\nBuecher Inventar:");
                        Console.WriteLine("{0,-40} | {1,-9}", "Buch", "Autor");
                        Console.WriteLine("____________________________________________________________________");
                        foreach (var buch in buecher_inventar)
                        {
                            Console.WriteLine("{0,-40} | {1,-9}", buch.Titel, buch.Author);
                        }
                        Console.WriteLine("\nBeliebige Taste drücken zum Fortfahren.");
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Clear();

                        Console.WriteLine($"Buch hinzufügen");
                        Console.WriteLine($"==================================================");
                        Console.WriteLine("");
                        Console.WriteLine("Fügen Sie ein Buch dem Inventar hinzu.");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.Write($"Geben Sie den Buchtitel an: ");
                        uiBookAddTitel = Console.ReadLine();
                        Console.WriteLine("");
                        Console.Write($"Geben Sie den Author an: ");
                        uiBookAddAuthor = Console.ReadLine();
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine($"Folgendes Buch wird hinzugefügt");
                        Console.WriteLine($"Buchtitel: {uiBookAddTitel}");
                        Console.WriteLine($"Buchauthor: {uiBookAddAuthor}");
                        Console.WriteLine("");
                        Console.Write("Soll das Buch hinzugefügt werden? [y/n]");
                        uiConfirmBookAdd = Console.ReadLine();
                        switch (uiConfirmBookAdd)
                        {
                            case "y":
                                buecher_inventar.Add(new Buch() { Titel = uiBookAddTitel, Author = uiBookAddAuthor });
                                Console.WriteLine("");
                                Console.WriteLine("Das Buch wurde erfolgreich hinzugefügt");
                                break;
                            case "n":
                                uiBookAddAuthor = "";
                                uiBookAddTitel = "";
                                Console.WriteLine("Es wurde kein Buch hinzugefügt");
                                break;
                            default:
                                break;
                        }
                        break;

                    case "3":
                        bool buchgefunden = false;
                        Console.Clear();
                        Console.Write("Suche nach einem Buch: ");
                        string suche = Console.ReadLine().ToLower();
                        if (!string.IsNullOrEmpty(suche))
                        {
                            for (int i = 0; i < buecher_inventar.Count; i++)
                            {
                                if (buecher_inventar[i].Titel.ToLower().Contains(suche))
                                {
                                    buchgefunden = true;

                                    Console.WriteLine("{0,-40} | {1,-9}", "Buch", "Autor");
                                    Console.WriteLine("____________________________________________________________________");
                                    Console.WriteLine("{0,-40} | {1,-9}", buecher_inventar[i].Titel, buecher_inventar[i].Author);
                                    Console.WriteLine("\nWollen sie dieses Buch ausleihen y/n:");
                                    string auswahlverschieben = Console.ReadLine();

                                    if (auswahlverschieben=="y")
                                    {
                                        buecher_ausgeliehen.Add(buecher_inventar[i]);
                                        buecher_inventar.RemoveAt(i);
                                        Console.WriteLine("Buch wurde ausgeliehen");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Buch nicht ausgeliehen");
                                    }
                                    Console.WriteLine("\nBeliebige Taste drücken zum Fortfahren.");
                                    Console.ReadKey();
                                }
                            }
                            if (!buchgefunden)
                            {
                                Console.WriteLine("\nBuch nicht gefunden.");
                                Console.WriteLine("\nBeliebige Taste drücken zum Fortfahren.");
                                Console.ReadKey();
                            }
                        }
                        break;

                    case "4":
                        buchgefunden = false;
                        Console.Clear();
                        Console.Write("Suche nach einem Buch: ");
                        suche = "";
                        suche = Console.ReadLine().ToLower();
                        if (!string.IsNullOrEmpty(suche))
                        {
                            for (int i = 0; i < buecher_ausgeliehen.Count; i++)
                            {
                                if (buecher_ausgeliehen[i].Titel.ToLower().Contains(suche))
                                {
                                    buchgefunden = true;

                                    Console.WriteLine("{0,-40} | {1,-9}", "Buch", "Autor");
                                    Console.WriteLine("____________________________________________________________________");
                                    Console.WriteLine("{0,-40} | {1,-9}", buecher_ausgeliehen[i].Titel, buecher_ausgeliehen[i].Author);
                                    Console.WriteLine("\nWollen sie dieses Buch ausleihen y/n:");
                                    string auswahlverschieben = Console.ReadLine();

                                    if (auswahlverschieben == "y")
                                    {
                                        buecher_inventar.Add(buecher_ausgeliehen[i]);
                                        buecher_ausgeliehen.RemoveAt(i);
                                        Console.WriteLine("Buch wurde ausgeliehen");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Buch nicht ausgeliehen");
                                    }
                                    Console.WriteLine("\nBeliebige Taste drücken zum Fortfahren.");
                                    Console.ReadKey();
                                }
                            }
                            if (!buchgefunden)
                            {
                                Console.WriteLine("\nBuch nicht gefunden.");
                                Console.WriteLine("\nBeliebige Taste drücken zum Fortfahren.");
                                Console.ReadKey();
                            }
                        }
                        break;

                    case "5":
                        Console.Clear();
                        Console.WriteLine("\nAusgeliehene Buecher:");
                        Console.WriteLine("{0,-40} | {1,-9}", "Buch", "Autor");
                        Console.WriteLine("____________________________________________________________________");
                        foreach (var buch in buecher_ausgeliehen)
                        {
                            Console.WriteLine("{0,-40} | {1,-9}", buch.Titel, buch.Author);
                        }
                        Console.WriteLine("\nBeliebige Taste drücken zum Fortfahren.");
                        Console.ReadKey();
                        break;

                    case "6":
                        break;

                    case "x":
                        break;

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
