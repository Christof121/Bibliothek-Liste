using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek_Liste
{
    class Buch // Definiert eine Klasse namens 'Buch', die als Vorlage für Buch-Objekte dient.
    {   // Eigenschaften 'Titel' , 'Author' und 'Anzahl' werden erstellt. 
        // 'get; set;' erstellt die Getter- und Setter-Methoden, 
        // um den Wert der Eigenschaft zu lesen und zu schreiben.
        public string Titel { get; set; }
        public string Author { get; set; }
        public int Anzahl { get; set; }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            bool menue = true;

            Console.Title = "Bibliothek";
            // Erstellt eine neue Liste von Buch-Objekten namens 'buecher_inventar'.
            // In der List<Buch> können 'Buch'-Objekte gespeichert werden.
            List<Buch> buecher_inventar = new List<Buch>() {
                new Buch() { Titel = "Vom Winde verweht", Author = "Hans Mueller", Anzahl = 2 },
                new Buch() { Titel = "Vom Sturm verweht", Author = "Hans Mueller", Anzahl = 1 },
                new Buch() { Titel = "Der Herr der Ringe", Author = "J.R.R. Tolkien", Anzahl = 3 },
                new Buch() { Titel = "Stolz und Vorurteil", Author = "Jane Austen", Anzahl = 1 },
                new Buch() { Titel = "1984", Author = "George Orwell", Anzahl = 4 },
                new Buch() { Titel = "Die Verwandlung", Author = "Franz Kafka", Anzahl = 1 },
                new Buch() { Titel = "Faust", Author = "Johann Wolfgang von Goethe", Anzahl = 2 },
                new Buch() { Titel = "Harry Potter und der Stein der Weisen", Author = "J.K. Rowling", Anzahl = 5 },
                new Buch() { Titel = "Der Schatten des Windes", Author = "Carlos Ruiz Zafón", Anzahl = 2 },
                new Buch() { Titel = "Der Alchemist", Author = "Paulo Coelho", Anzahl = 1 },
                new Buch() { Titel = "Das Parfum", Author = "Patrick Süskind", Anzahl = 3 },
                new Buch() { Titel = "Krieg und Frieden", Author = "Leo Tolstoi", Anzahl = 1 },
                new Buch() { Titel = "Der Fänger im Roggen", Author = "J.D. Salinger", Anzahl = 1 },
                new Buch() { Titel = "Die unendliche Geschichte", Author = "Michael Ende", Anzahl = 4 },
                new Buch() { Titel = "Moby Dick", Author = "Herman Melville", Anzahl = 1 },
                new Buch() { Titel = "Der kleine Prinz", Author = "Antoine de Saint-Exupéry", Anzahl = 5 },
                new Buch() { Titel = "Die Säulen der Erde", Author = "Ken Follett", Anzahl = 2 },
                new Buch() { Titel = "Sakrileg", Author = "Dan Brown", Anzahl = 3 },
                new Buch() { Titel = "Per Anhalter durch die Galaxis", Author = "Douglas Adams", Anzahl = 1 },
                new Buch() { Titel = "Der Medicus", Author = "Noah Gordon", Anzahl = 2 },
                new Buch() { Titel = "Wer die Nachtigall stört", Author = "Harper Lee", Anzahl = 1 },
                new Buch() { Titel = "Der Name der Rose", Author = "Umberto Eco", Anzahl = 1 }
            };

            // Sortiert die Liste 'buecher_inventar' alphabetisch nach dem Titel.
            // ToList() wandelt das sortierte Ergebnis zurück in eine List<Buch>.
            buecher_inventar = buecher_inventar.OrderBy(Buch => Buch.Titel).ToList();

            //Console.WriteLine(buecher[1].Author);

            /*
            buecher_inventar = buecher_inventar.OrderBy(Buch => Buch.Titel).ToList();

            foreach (var item in buecher_inventar)
            {
                Console.WriteLine(item.Titel);
            }
            */

            List<Buch> buecher_ausgeliehen = new List<Buch>();
            // Erstellt eine leere Liste für die ausgeliehenen Bücher.

            do
            {
                #region Menue

                Console.WriteLine($"Bibliothek");
                Console.WriteLine($"==================================================");
                Console.WriteLine($"1) Bücher ansehen");
                Console.WriteLine($"2) Bücher hinzufuegen");
                Console.WriteLine($"3) Bücher ausleihen");
                Console.WriteLine($"4) Bücher zurueckgeben");
                Console.WriteLine($"5) Ausgeliehene Buecher ausgeben");
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
                    // Fall 1: Bücher im Inventar ansehen
                    case "1":
                        Console.Clear();
                        Console.Write("Wie möchten Sie die Liste sortieren? ([T]itel / [A]utor): ");
                        string sortWahl = Console.ReadLine();
                        string sortWahlstandard = "t"; // Standardmäßig nach Titel sortieren
                        buecher_inventar = buecher_inventar.OrderBy(Buch => Buch.Titel).ToList();

                        if (!string.IsNullOrEmpty(sortWahl))
                        {
                            sortWahlstandard = sortWahl.ToLower();
                        }

                        if (sortWahlstandard == "t" || sortWahlstandard == "titel")
                        {
                            // Sortiere die Liste nach Titel
                            buecher_inventar = buecher_inventar.OrderBy(Buch => Buch.Titel).ToList();
                            Console.WriteLine("\nBücher Inventar (sortiert nach Titel):");
                        }

                        else if (sortWahlstandard == "a" || sortWahlstandard == "autor")
                        {
                            // Sortiere die Liste nach Autor
                            buecher_inventar = buecher_inventar.OrderBy(Buch => Buch.Author).ToList();
                            Console.WriteLine("\nBücher Inventar (sortiert nach Author):");
                        }

                        Console.WriteLine("{0,-40} | {1,-26} | {2,-6}", "Buch", "Autor", "Anzahl");
                        Console.WriteLine("______________________________________________________________________________");
                        foreach (var buch in buecher_inventar)
                        {
                            Console.WriteLine("{0,-40} | {1,-26} | {2,-6}", buch.Titel, buch.Author, buch.Anzahl);
                        }

                        // Sortiere die Liste zurück nach Titel    
                        if (sortWahlstandard == "a" || sortWahlstandard == "autor") buecher_inventar = buecher_inventar.OrderBy(Buch => Buch.Titel).ToList();

                        Console.WriteLine("\nBeliebige Taste drücken zum Fortfahren.");
                        Console.ReadKey();
                        /*
                        Ohne sortierungswahl
                        Console.Clear();
                        Console.WriteLine("\nBuecher Inventar:");
                        // {0,-40} bedeutet: Platzhalter 0, linksbündig (-), auf 40 Zeichen Breite.
                        // {1,-9}  bedeutet: Platzhalter 1, linksbündig (-), auf 9 Zeichen Breite.
                        Console.WriteLine("{0,-40} | {1,-26} | {2,-6}", "Buch", "Autor", "Anzahl");
                        Console.WriteLine("______________________________________________________________________________");
                        foreach (var buch in buecher_inventar)
                        {
                            Console.WriteLine("{0,-40} | {1,-26} | {2,-6}", buch.Titel, buch.Author, buch.Anzahl);
                        }
                        Console.WriteLine("\nBeliebige Taste drücken zum Fortfahren.");
                        Console.ReadKey();
                        */
                        break;

                    // Fall 2: Neues Buch hinzufügen
                    case "2":

                        Console.Clear();
                        Console.WriteLine($"Buch hinzufügen");
                        Console.WriteLine($"==================================================");
                        Console.WriteLine("");
                        Console.WriteLine("Fügen Sie ein Buch dem Inventar hinzu.");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.Write($"Geben Sie den Buchtitel an: ");
                        string uiBookAddTitel = Console.ReadLine();
                        Console.WriteLine("");
                        Console.Write($"Geben Sie den Author an: ");
                        string uiBookAddAuthor = Console.ReadLine();
                        Console.WriteLine("");
                        int uiBookAddAnzahl = 0;
                        do {
                            Console.Write($"Geben Sie den Anzahl der Bücher an: ");
                            //string uiBookAddAnzahl = Console.ReadLine();
                            if (int.TryParse(Console.ReadLine(), out uiBookAddAnzahl) && uiBookAddAnzahl > 0)
                            {
                                break;
                            }
                            Console.WriteLine("Eingabe fehlerhaft, bitte Wiederholen.");
                        } while (true);
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine($"Folgendes Buch wird hinzugefügt");

                        Console.WriteLine("{0,-40} | {1,-26} | {2,-6}", "Buch", "Autor", "Anzahl");
                        Console.WriteLine("______________________________________________________________________________");
                        Console.WriteLine($"{uiBookAddTitel,-40} | {uiBookAddAuthor,-26} | {uiBookAddAnzahl,-6}");

                        Console.WriteLine("");
                        Console.Write("Soll das Buch hinzugefügt werden? [y/n]");
                        string uiConfirmBookAdd = Console.ReadLine();
                        switch (uiConfirmBookAdd)
                        {
                            case "y":
                                // Erstellt ein neues Buch-Objekt mit den eingegebenen Daten und fügt es zur Inventarliste hinzu.
                                buecher_inventar.Add(new Buch() { Titel = uiBookAddTitel, Author = uiBookAddAuthor, Anzahl = uiBookAddAnzahl });
                                // Sortiert die Liste erneut, damit das neue Buch an der richtigen Stelle steht.
                                // OrderBy gibt eine Sortierte Sequenz der Klasse Buch nach der Eigenschaft Titel zurück.
                                // .ToList() wandelt das Ergebnis in eine Liste um.
                                buecher_inventar = buecher_inventar.OrderBy(Buch => Buch.Titel).ToList();
                                Console.WriteLine("");
                                Console.WriteLine("Das Buch wurde erfolgreich hinzugefügt");
                                break;
                            case "n": //Buch Eingabe abbrechen
                                uiBookAddAuthor = "";
                                uiBookAddTitel = "";
                                Console.WriteLine("Es wurde kein Buch hinzugefügt");
                                break;
                            default: //Fehlerhafte Eingabe
                                Console.WriteLine("Eingabe fehlerhaft");
                                break;
                        }
                        break;

                    // Fall 3: Buch ausleihen
                    case "3":

                        // Variable, um zu prüfen, ob ein passendes Buch gefunden wurde.
                        bool buchgefunden = false;
                        Console.Clear();
                        Console.Write("Suche nach einem Buch zum ausleihen: ");
                        string suche = Console.ReadLine().ToLower();
                        // Prüft, ob ein Suchbegriff eingegeben wurde.
                        if (!string.IsNullOrEmpty(suche))
                        {
                            for (int i = 0; i < buecher_inventar.Count; i++)
                            {
                                //mit Contains wird überprüft ob der Titel des Buches den Suchbegriff enthält
                                if (buecher_inventar[i].Titel.ToLower().Contains(suche))
                                {
                                    bool ausgeliehenGefunden = false;
                                    buchgefunden = true;
                                    //gefundenes Buch wird angezeigt.
                                    Console.WriteLine("{0,-40} | {1,-26} | {2,-6}", "Buch", "Autor", "Anzahl");
                                    Console.WriteLine("______________________________________________________________________________");
                                    Console.WriteLine("{0,-40} | {1,-26} | {2,-6}", buecher_inventar[i].Titel, buecher_inventar[i].Author, buecher_inventar[i].Anzahl);
                                    Console.Write("\nWollen sie dieses Buch ausleihen y/n: ");
                                    string auswahlverschieben = Console.ReadLine();

                                    if (auswahlverschieben.ToLower() == "y" && buecher_inventar[i].Anzahl > 0)//es wird die Eingabe geprüft und ob das Buch in ausreichender Anzahl vorhanden ist
                                    {
                                        // Fügt das Buch zur Liste der ausgeliehenen Bücher hinzu.
                                        for (int j = 0; j < buecher_ausgeliehen.Count; j++)
                                        {
                                            // Vergleicht das auszuleihende Buch mit den bereits ausgeliehenen Büchern
                                            if (buecher_ausgeliehen[j].Titel == buecher_inventar[i].Titel && buecher_ausgeliehen[j].Author == buecher_inventar[i].Author)
                                            {
                                                buecher_ausgeliehen[j].Anzahl++; // Erhöhe Anzahl
                                                ausgeliehenGefunden = true;
                                            }
                                        }
                                        // Wenn das Buch noch nicht vorhanden ist wird es hinzugefügt
                                        if (!ausgeliehenGefunden)
                                        {
                                            buecher_ausgeliehen.Add(new Buch() { Titel = buecher_inventar[i].Titel, Author = buecher_inventar[i].Author, Anzahl = 1 });
                                            buecher_inventar = buecher_inventar.OrderBy(Buch => Buch.Titel).ToList();
                                        }

                                        // Verringert die Anzahl des Buches im Inventar um 1
                                        buecher_inventar[i].Anzahl--;

                                        Console.WriteLine("Buch wurde ausgeliehen");
                                    }

                                    else if (auswahlverschieben.ToLower() == "y" && buecher_inventar[i].Anzahl == 0)
                                    {
                                        Console.WriteLine("Buch nicht verfügbar");
                                    }

                                    else //wenn das Buch nicht ausgeliehen werden soll
                                    {
                                        Console.WriteLine("Buch nicht ausgeliehen");
                                    }


                                    Console.WriteLine("\nBeliebige Taste drücken zum Fortfahren.");
                                    Console.ReadKey();
                                }
                            }
                            if (!buchgefunden) // Wenn kein passendes Buch gefunden wurde
                            {
                                Console.WriteLine("\nBuch nicht gefunden.");
                                Console.WriteLine("\nBeliebige Taste drücken zum Fortfahren.");
                                Console.ReadKey();
                            }
                        }
                        else // Falls der Benutzer nichts eingegeben hat.
                        {
                            Console.WriteLine("\nLeere Sucheingabe.");
                            Console.WriteLine("\nBeliebige Taste drücken zum Fortfahren.");
                            Console.ReadKey();
                        }
                        break;

                    // Fall 4: Buch zurückgeben
                    case "4":

                        // Variable, um zu prüfen, ob ein passendes Buch gefunden wurde.
                        buchgefunden = false;
                        Console.Clear();
                        Console.Write("Suche nach einem Buch zum zurückgeben: ");
                        suche = Console.ReadLine().ToLower();
                        // Prüft, ob ein Suchbegriff eingegeben wurde.
                        if (!string.IsNullOrEmpty(suche))
                        {
                            for (int i = 0; i < buecher_ausgeliehen.Count; i++)
                            {
                                bool inventarGefunden = false;
                                //mit Contains wird überprüft ob der Titel des Buches den Suchbegriff enthält
                                if (buecher_ausgeliehen[i].Titel.ToLower().Contains(suche) && buecher_ausgeliehen[i].Anzahl > 0)
                                {
                                    buchgefunden = true;
                                    //gefundenes Buch wird angezeigt.
                                    Console.WriteLine("{0,-40} | {1,-26} | {2,-6}", "Buch", "Autor", "Anzahl");
                                    Console.WriteLine("______________________________________________________________________________");
                                    Console.WriteLine("{0,-40} | {1,-26} | {2,-6}", buecher_ausgeliehen[i].Titel, buecher_ausgeliehen[i].Author, buecher_ausgeliehen[i].Anzahl);
                                    Console.Write("\nWollen sie dieses Buch zurückgeben y/n: ");
                                    string auswahlverschieben = Console.ReadLine();

                                    if (auswahlverschieben.ToLower() == "y")
                                    {
                                        // Das Buch wird in die Inventarliste zurückgegeben. Und gegebenenfalls gelöscht.

                                        for (int j = 0; j < buecher_inventar.Count; j++)
                                        {
                                            // Vergleicht das zurückzugebene Buch mit den bereits Inventar Büchern
                                            if (buecher_inventar[j].Titel == buecher_ausgeliehen[i].Titel && buecher_inventar[j].Author == buecher_ausgeliehen[i].Author)
                                            {
                                                buecher_inventar[j].Anzahl++; // Erhöhe Anzahl
                                                inventarGefunden = true;
                                            }
                                        }

                                        // Verringert die Anzahl des Buches im in der Ausgeliehen Liste um 1
                                        buecher_ausgeliehen[i].Anzahl--;

                                        Console.WriteLine("Buch wurde ausgeliehen");

                                        if (buecher_ausgeliehen[i].Anzahl == 0)
                                        {
                                            buecher_ausgeliehen.RemoveAt(i); // Entferne aus der Liste
                                            --i; // Korrigiere Schleifenzähler !!!
                                        }
                                    }


                                    else //wenn das Buch nicht ausgeliehen werden soll
                                    {
                                        Console.WriteLine("Buch nicht ausgeliehen");
                                    }

                                    Console.WriteLine("\nBeliebige Taste drücken zum Fortfahren.");
                                    Console.ReadKey();
                                }
                            }
                            if (!buchgefunden) // Wenn kein passendes Buch gefunden wurde
                            {
                                Console.WriteLine("\nBuch nicht gefunden.");
                                Console.WriteLine("\nBeliebige Taste drücken zum Fortfahren.");
                                Console.ReadKey();
                            }
                        }
                        else // Falls der Benutzer nichts eingegeben hat.
                        {
                            Console.WriteLine("\nLeere Sucheingabe.");
                            Console.WriteLine("\nBeliebige Taste drücken zum Fortfahren.");
                            Console.ReadKey();
                        }
                        /* 
                         Code noch ohne Anzahl
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

                                     Console.WriteLine("{0,-40} | {1,-26}", "Buch", "Autor");
                                     Console.WriteLine("____________________________________________________________________");
                                     Console.WriteLine("{0,-40} | {1,-26}", buecher_ausgeliehen[i].Titel, buecher_ausgeliehen[i].Author);
                                     Console.WriteLine("\nWollen sie dieses Buch zurückgeben y/n:");
                                     string auswahlverschieben = Console.ReadLine();

                                     if (auswahlverschieben == "y")
                                     {
                                         buecher_inventar.Add(buecher_ausgeliehen[i]);
                                         buecher_ausgeliehen.RemoveAt(i);
                                         --i;
                                         Console.WriteLine("Buch wurde zurückgegeben");
                                     }
                                     else
                                     {
                                         Console.WriteLine("Buch nicht zurückgegeben");
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
                         else
                         {
                             Console.WriteLine("\nLeere Sucheingabe.");
                             Console.WriteLine("\nBeliebige Taste drücken zum Fortfahren.");
                             Console.ReadKey();
                         }
                        */

                        break;

                    // Fall 5: Ausgeliehene Bücher anzeigen
                    case "5":

                        Console.Clear();
                        Console.WriteLine("\nAusgeliehene Buecher:");
                        Console.WriteLine("{0,-40} | {1,-26} | {2,-6}", "Buch", "Autor", "Anzahl");
                        Console.WriteLine("______________________________________________________________________________");
                        foreach (var buch in buecher_ausgeliehen)
                        {
                            Console.WriteLine("{0,-40} | {1,-26} | {2,-6}", buch.Titel, buch.Author, buch.Anzahl);
                        }
                        Console.WriteLine("\nBeliebige Taste drücken zum Fortfahren.");
                        Console.ReadKey();
                        break;

                    // Fall 6: Buch dauerhaft aus dem Inventar entfernen
                    case "6":

                        string uiBookRemoveTitel = "";
                        Console.Clear();
                        Console.WriteLine($"Buch Löschen");
                        Console.WriteLine($"==================================================");
                        Console.WriteLine("");
                        Console.WriteLine("Welchen Buchtitel möchten Sie löschen?");
                        Console.WriteLine("");
                        Console.Write("Eingabe: ");
                        uiBookRemoveTitel = Console.ReadLine().ToLower();
                        buchgefunden = false;
                        if (!string.IsNullOrEmpty(uiBookRemoveTitel))
                        {
                            for (int i = 0; i < buecher_inventar.Count; i++)
                            {
                                if (buecher_inventar[i].Titel.ToLower().Contains(uiBookRemoveTitel))
                                {
                                    buchgefunden = true;

                                    Console.WriteLine("{0,-40} | {1,-26}", "Buch", "Autor");
                                    Console.WriteLine("____________________________________________________________________");
                                    Console.WriteLine("{0,-40} | {1,-26}", buecher_inventar[i].Titel, buecher_inventar[i].Author);
                                    Console.WriteLine("\nWollen sie dieses Buch löschen? y/n:");
                                    string auswahlloeschen = Console.ReadLine();

                                    if (auswahlloeschen == "y")
                                    {
                                        // Buch an der aktuellen Position 'i' aus dem Inventar entfernen.
                                        buecher_inventar.RemoveAt(i);
                                        Console.WriteLine("Buch wurde gelöscht");
                                        --i;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Buch nicht gelöscht");
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
                        else // Falls der Benutzer nichts eingegeben hat.
                        {
                            Console.WriteLine("\nLeere Sucheingabe.");
                            Console.WriteLine("\nBeliebige Taste drücken zum Fortfahren.");
                            Console.ReadKey();
                        }
                        /*
                        uiBookRemoveTitel = Console.ReadLine();
                        int index = buecher_inventar.FindIndex(e => e.Titel == uiBookRemoveTitel);
                        Console.WriteLine("");
                        if (index == -1) {
                            Console.WriteLine("Es wurde kein Buch mit dem Titel gefunden");
                            break;
                        }
                        Console.WriteLine("");
                        Console.WriteLine("Folgendes Buch wurde gefunden");
                        Console.WriteLine($"{buecher_inventar[index].Titel}");
                        Console.WriteLine($"{buecher_inventar[index].Author}");
                        Console.WriteLine("");
                        Console.Write("Soll das Buch gelöscht werden? [y/n]");
                        uiConfirmBookRemove = Console.ReadLine();
                        switch (uiConfirmBookRemove)
                        {
                            case "y":
                                buecher_inventar.RemoveAt(index);
                                Console.WriteLine("");
                                Console.WriteLine("Das Buch wurde erfolgreich gelöscht");
                                break;
                            case "n":
                                uiBookRemoveTitel = "";
                                Console.WriteLine("Es wurde kein Buch gelöscht");
                                break;
                            default:
                                Console.WriteLine("Eingabe fehlerhaft");
                                break;
                        }
                        //buecher_inventar.Remove(uiBookRemoveTitel);
                        */
                        break;

                    // Fall x: Programm beenden
                    case "x":

                        Console.WriteLine("");
                        Console.WriteLine("Das Programm wurde beendet");
                        menue = false;
                        break;

                    default:
                        Console.WriteLine($"");
                        Console.WriteLine("Eingabe Fehlerhaft");
                        Console.WriteLine("Bitte wiederholen Sie ihre Eingabe.");
                        break;
                }
                ;
                Console.WriteLine();
                Console.WriteLine("Drücken Sie eine beliebige Taste um fortzufahren ...");
                Console.ReadKey();
                Console.Clear();
            } while (menue);
        }
    }
}
