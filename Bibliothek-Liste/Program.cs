﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bibliothek_Methoden
{
    class Buch // Definiert eine Klasse namens 'Buch', die als Vorlage für Buch-Objekte dient.
    {   // Eigenschaften 'Titel' , 'Autor' und 'Anzahl' werden erstellt. 
        // 'get; set;' erstellt die Getter- und Setter-Methoden, 
        // um den Wert der Eigenschaft zu lesen und zu schreiben.
        public string Titel { get; set; }
        public string Autor { get; set; }
        public int Anzahl { get; set; }

    }
    internal class Program
    {
        //können auch zb als static List<Buch> (Übergabeargumente); deklariert werden um Buchlisten direkt darin zu verarbeiten und auch wieder ausgeben zu können.
        static void Buchausgabe(List<Buch> buecher_ausgabe)
        {
            Console.WriteLine("{0,-40} | {1,-26} | {2,-6}", "Buch", "Autor", "Anzahl");
            Console.WriteLine("______________________________________________________________________________");

            foreach (var buch in buecher_ausgabe)
            {
                Console.WriteLine("{0,-40} | {1,-26} | {2,-6}", buch.Titel, buch.Autor, buch.Anzahl);
            }

        }
        static void Buchbearbeitung(List<Buch> buecher_input, List<Buch> buecher_output, int operation)
        {
            int i = 0;
            Console.WriteLine("\nGefundene Bücher:):");
            Console.WriteLine("{0,-6} | {1,-40} | {2,-26} | {3,-6}", "Index", "Buch", "Autor", "Anzahl");
            Console.WriteLine("_______________________________________________________________________________________");
            foreach (var buch in buecher_input)
            {
                Console.WriteLine("{0,-6} | {1,-40} | {2,-26} | {3,-6}", i, buch.Titel, buch.Autor, buch.Anzahl);
                i++;
            }
            //Bücher ausleihen
            if (operation == 1)
            {
                Console.Write("\nWählen Sie den Index des Buches, das Sie ausleihen möchten oder x zum Abbrechen: ");
                string index = Console.ReadLine();
                if (!string.IsNullOrEmpty(index) && index.ToLower() != "x")
                {
                    bool ausgeliehenGefunden = false;
                    int.TryParse(index, out int indexInt);
                    for (int j = 0; j < buecher_output.Count; j++)
                    {

                        // Vergleicht das auszuleihende Buch mit den bereits ausgeliehenen Büchern
                        if (buecher_output[j].Titel == buecher_input[indexInt].Titel && buecher_output[j].Autor == buecher_input[indexInt].Autor)
                        {
                            buecher_output[j].Anzahl++; // Erhöhe Anzahl
                            ausgeliehenGefunden = true;
                        }
                    }
                    // Wenn das Buch noch nicht vorhanden ist wird es hinzugefügt
                    if (!ausgeliehenGefunden)
                    {
                        buecher_output.Add(new Buch() { Titel = buecher_input[indexInt].Titel, Autor = buecher_input[indexInt].Autor, Anzahl = 1 });
                    }

                    // Verringert die Anzahl des Buches im Inventar um 1
                    buecher_input[indexInt].Anzahl--;

                    Console.WriteLine("Buch wurde ausgeliehen");
                }
                else if (index.ToLower() == "x") Console.WriteLine("Buch wurde nicht ausgeliehen");

                else Console.WriteLine("Fehlerhafte Eingabe");

            }

            //Bücher zurückgeben
            else if (operation == 2)
            {
                Console.Write("\nWählen Sie den Index des Buches, das Sie zurückgeben möchten oder x zum Abbrechen: ");
                string index = Console.ReadLine();
                if (!string.IsNullOrEmpty(index) && index.ToLower() != "x")
                {
                    bool ausgeliehenGefunden = false;
                    int.TryParse(index, out int indexInt);
                    for (int j = 0; j < buecher_output.Count; j++)
                    {

                        // Vergleicht das auszuleihende Buch mit den bereits ausgeliehenen Büchern
                        if (buecher_output[j].Titel == buecher_input[indexInt].Titel && buecher_output[j].Autor == buecher_input[indexInt].Autor)
                        {
                            buecher_output[j].Anzahl++; // Erhöhe Anzahl
                            ausgeliehenGefunden = true;
                        }
                    }
                    // Wenn das Buch noch nicht vorhanden ist wird es hinzugefügt
                    if (!ausgeliehenGefunden)
                    {
                        buecher_output.Add(new Buch() { Titel = buecher_input[indexInt].Titel, Autor = buecher_input[indexInt].Autor, Anzahl = 1 });
                    }

                    // Verringert die Anzahl des Buches im Inventar um 1
                    buecher_input[indexInt].Anzahl--;
                    if (buecher_input[indexInt].Anzahl == 0) buecher_input.RemoveAt(indexInt); // Entferne aus der Liste



                    Console.WriteLine("Buch wurde zurückgegeben");
                }
                else if (index.ToLower() == "x") Console.WriteLine("Buch wurde nicht zurückgegeben");
                else Console.WriteLine("Fehlerhafte Eingabe");

            }

            //Bücher löschen
            else if (operation == 3)
            {
                Console.Write("\nWählen Sie den Index des Buches, das Sie löschen möchten oder x zum Abbrechen: ");
                string index = Console.ReadLine();
                if (!string.IsNullOrEmpty(index) && index.ToLower() != "x")
                {
                    int.TryParse(index, out int indexInt);
                    Console.Clear();
                    Console.WriteLine("{0,-40} | {1,-26} | {2,-6}", "Buch", "Autor", "Anzahl");
                    Console.WriteLine("______________________________________________________________________________");
                    Console.WriteLine("{0,-40} | {1,-26} | {2,-6}", buecher_input[indexInt].Titel, buecher_input[indexInt].Autor, buecher_input[indexInt].Anzahl);

                    Console.Write("Wollen Sie dieses Buch wirklich löschen? y/n:");
                    string auswahlloeschen = Console.ReadLine().ToLower();
                    if (auswahlloeschen == "y")
                    {
                        Buch buchzuloeaschen = buecher_input[indexInt];
                        Console.Write("Wollen sie alle Exemplare entfernen? y/n:");
                        auswahlloeschen = Console.ReadLine().ToLower();
                        if (auswahlloeschen == "y")
                        {
                            buecher_output.Remove(buchzuloeaschen);
                            Console.WriteLine("Buch wurde gelöscht");
                        }
                        else
                        {
                            Console.WriteLine("Wie viele Exemplare wollen sie löschen?");
                            Console.WriteLine("Sinkt die Anzahl auf 0 wird der ganze Eintrag gelöscht");
                            Console.WriteLine("Mit x können Sie abbrechen");
                            Console.Write("Eingabe: ");
                            string eingabe = Console.ReadLine().ToLower();
                            if (eingabe != "x")
                            {
                                int.TryParse(eingabe, out int eingabeInt);
                                if (eingabeInt > 0)
                                {
                                    buecher_input[indexInt].Anzahl -= eingabeInt;
                                    if (buecher_input[indexInt].Anzahl <= 0) buecher_output.Remove(buchzuloeaschen);  // Entferne aus der Liste
                                    Console.WriteLine("Buch wurde gelöscht");
                                }
                                else Console.WriteLine("Fehlerhafte Eingabe");
                            }
                            else
                            {
                                Console.WriteLine("Buch nicht gelöscht");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Buch nicht gelöscht");
                    }
                }
                else if (index.ToLower() == "x") Console.WriteLine("Buch wurde nicht gelöscht");
                else Console.WriteLine("Fehlerhafte Eingabe");
            }
        }
        static void Main(string[] args)
        {
            bool menue = true;

            Console.Title = "Bibliothek";
            // Erstellt eine neue Liste von Buch-Objekten namens 'buecher_inventar'.
            // In der List<Buch> können 'Buch'-Objekte gespeichert werden.
            List<Buch> buecher_inventar = new List<Buch>() {
                new Buch() { Titel = "Vom Winde verweht", Autor = "Hans Mueller", Anzahl = 2 },
                new Buch() { Titel = "Vom Sturm verweht", Autor = "Hans Mueller", Anzahl = 1 },
                new Buch() { Titel = "Der Herr der Ringe", Autor = "J.R.R. Tolkien", Anzahl = 3 },
                new Buch() { Titel = "Stolz und Vorurteil", Autor = "Jane Austen", Anzahl = 1 },
                new Buch() { Titel = "1984", Autor = "George Orwell", Anzahl = 4 },
                new Buch() { Titel = "Die Verwandlung", Autor = "Franz Kafka", Anzahl = 1 },
                new Buch() { Titel = "Faust", Autor = "Johann Wolfgang von Goethe", Anzahl = 2 },
                new Buch() { Titel = "Harry Potter und der Stein der Weisen", Autor = "J.K. Rowling", Anzahl = 5 },
                new Buch() { Titel = "Der Schatten des Windes", Autor = "Carlos Ruiz Zafón", Anzahl = 2 },
                new Buch() { Titel = "Der Alchemist", Autor = "Paulo Coelho", Anzahl = 1 },
                new Buch() { Titel = "Das Parfum", Autor = "Patrick Süskind", Anzahl = 3 },
                new Buch() { Titel = "Krieg und Frieden", Autor = "Leo Tolstoi", Anzahl = 1 },
                new Buch() { Titel = "Der Fänger im Roggen", Autor = "J.D. Salinger", Anzahl = 1 },
                new Buch() { Titel = "Die unendliche Geschichte", Autor = "Michael Ende", Anzahl = 4 },
                new Buch() { Titel = "Moby Dick", Autor = "Herman Melville", Anzahl = 1 },
                new Buch() { Titel = "Der kleine Prinz", Autor = "Antoine de Saint-Exupéry", Anzahl = 5 },
                new Buch() { Titel = "Die Säulen der Erde", Autor = "Ken Follett", Anzahl = 2 },
                new Buch() { Titel = "Sakrileg", Autor = "Dan Brown", Anzahl = 3 },
                new Buch() { Titel = "Per Anhalter durch die Galaxis", Autor = "Douglas Adams", Anzahl = 1 },
                new Buch() { Titel = "Der Medicus", Autor = "Noah Gordon", Anzahl = 2 },
                new Buch() { Titel = "Wer die Nachtigall stört", Autor = "Harper Lee", Anzahl = 1 },
                new Buch() { Titel = "Der Name der Rose", Autor = "Umberto Eco", Anzahl = 1 }
            };

            // Sortiert die Liste 'buecher_inventar' alphabetisch nach dem Titel.
            // ToList() wandelt das sortierte Ergebnis zurück in eine List<Buch>.
            buecher_inventar = buecher_inventar.OrderBy(Buch => Buch.Titel).ToList();

            //Console.WriteLine(buecher[1].Autor);

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

                Console.Write("Ihre Auswahl: ");
                string Auswahl = Console.ReadLine().ToLower();

                #endregion Menue

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
                            buecher_inventar = buecher_inventar.OrderBy(Buch => Buch.Autor).ToList();
                            Console.WriteLine("\nBücher Inventar (sortiert nach Autor):");
                        }

                        Buchausgabe(buecher_inventar);

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
                            Console.WriteLine("{0,-40} | {1,-26} | {2,-6}", buch.Titel, buch.Autor, buch.Anzahl);
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
                        Console.WriteLine("\nFügen Sie ein Buch dem Inventar hinzu.");
                        Console.Write($"\n\nGeben Sie den Buchtitel an: ");
                        string uiBookAddTitel = Console.ReadLine();
                        Console.Write($"\nGeben Sie den Autor an: ");
                        string uiBookAddAutor = Console.ReadLine();
                        Console.Write("Geben Sie die Anzahl an: ");
                        int uiBookAddAnzahl = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"\n\nFolgendes Buch wird hinzugefügt");

                        Console.WriteLine("{0,-40} | {1,-26} | {2,-6}", "Buch", "Autor", "Anzahl");
                        Console.WriteLine("______________________________________________________________________________");
                        Console.WriteLine("{0,-40} | {1,-26} | { 2,-6}", uiBookAddTitel, uiBookAddAutor, uiBookAddAnzahl);

                        Console.WriteLine("");
                        Console.Write("Soll das Buch hinzugefügt werden? [y/n]");
                        string uiConfirmBookAdd = Console.ReadLine();
                        switch (uiConfirmBookAdd)
                        {
                            case "y":
                                // Erstellt ein neues Buch-Objekt mit den eingegebenen Daten und fügt es zur Inventarliste hinzu.
                                buecher_inventar.Add(new Buch() { Titel = uiBookAddTitel, Autor = uiBookAddAutor, Anzahl = uiBookAddAnzahl });
                                // Sortiert die Liste erneut, damit das neue Buch an der richtigen Stelle steht.
                                // OrderBy gibt eine Sortierte Sequenz der Klasse Buch nach der Eigenschaft Titel zurück.
                                // .ToList() wandelt das Ergebnis in eine Liste um.
                                buecher_inventar = buecher_inventar.OrderBy(Buch => Buch.Titel).ToList();
                                Console.WriteLine("");
                                Console.WriteLine("Das Buch wurde erfolgreich hinzugefügt");
                                break;
                            case "n": //Buch Eingabe abbrechen
                                uiBookAddAutor = "";
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
                        do
                        {
                            // Prüft, ob ein Suchbegriff eingegeben wurde.
                            if (!string.IsNullOrEmpty(suche))
                            {
                                List<Buch> ausleihen = new List<Buch>();
                                for (int i = 0; i < buecher_inventar.Count; i++)
                                {

                                    //mit Contains wird überprüft ob der Titel des Buches den Suchbegriff enthält
                                    if (buecher_inventar[i].Titel.ToLower().Contains(suche))
                                    {

                                        buchgefunden = true;
                                        int j = 0;
                                        ausleihen.Add(buecher_inventar[i]);
                                        j++;
                                    }
                                }
                                Buchbearbeitung(ausleihen, buecher_ausgeliehen, 1);
                                Console.WriteLine("\nBeliebige Taste drücken zum Fortfahren.");
                                Console.ReadKey();
                            }
                            else if (!buchgefunden) // Wenn kein passendes Buch gefunden wurde
                            {
                                Console.WriteLine("\nBuch nicht gefunden.");
                                Console.WriteLine("\nBeliebige Taste drücken zum Fortfahren.");
                                Console.ReadKey();
                            }

                            else // Falls der Benutzer nichts eingegeben hat.
                            {
                                Console.WriteLine("\nLeere Sucheingabe.");
                                Console.WriteLine("\nBeliebige Taste drücken zum Fortfahren.");
                                Console.ReadKey();

                            }
                        } while (false);

                        break;

                    /*  // alt Variable, um zu prüfen, ob ein passendes Buch gefunden wurde.
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
                                 Console.WriteLine("{0,-40} | {1,-26} | {2,-6}", buecher_inventar[i].Titel, buecher_inventar[i].Autor, buecher_inventar[i].Anzahl);
                                 Console.Write("\nWollen sie dieses Buch ausleihen y/n: ");
                                 string auswahlverschieben = Console.ReadLine();

                                 if (auswahlverschieben.ToLower() == "y" && buecher_inventar[i].Anzahl > 0)//es wird die Eingabe geprüft und ob das Buch in ausreichender Anzahl vorhanden ist
                                 {
                                     // Fügt das Buch zur Liste der ausgeliehenen Bücher hinzu.
                                     for (int j = 0; j < buecher_ausgeliehen.Count; j++)
                                     {
                                         // Vergleicht das auszuleihende Buch mit den bereits ausgeliehenen Büchern
                                         if (buecher_ausgeliehen[j].Titel == buecher_inventar[i].Titel && buecher_ausgeliehen[j].Autor == buecher_inventar[i].Autor)
                                         {
                                             buecher_ausgeliehen[j].Anzahl++; // Erhöhe Anzahl
                                             ausgeliehenGefunden = true;
                                         }
                                     }
                                     // Wenn das Buch noch nicht vorhanden ist wird es hinzugefügt
                                     if (!ausgeliehenGefunden)
                                     {
                                         buecher_ausgeliehen.Add(new Buch() { Titel = buecher_inventar[i].Titel, Autor = buecher_inventar[i].Autor, Anzahl = 1 });
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
                    */
                    // Fall 4: Buch zurückgeben

                    case "4":

                        // Variable, um zu prüfen, ob ein passendes Buch gefunden wurde.
                        buchgefunden = false;
                        Console.Clear();
                        Console.Write("Suche nach einem Buch zum zurückgeben: ");
                        suche = Console.ReadLine().ToLower();
                        do
                        {
                            // Prüft, ob ein Suchbegriff eingegeben wurde.
                            if (!string.IsNullOrEmpty(suche))
                            {
                                List<Buch> zurückgeben = new List<Buch>();
                                for (int i = 0; i < buecher_ausgeliehen.Count; i++)
                                {

                                    //mit Contains wird überprüft ob der Titel des Buches den Suchbegriff enthält
                                    if (buecher_ausgeliehen[i].Titel.ToLower().Contains(suche))
                                    {

                                        buchgefunden = true;
                                        int j = 0;
                                        zurückgeben.Add(buecher_ausgeliehen[i]);
                                        j++;
                                    }
                                }
                                Buchbearbeitung(zurückgeben, buecher_ausgeliehen, 2);
                                Console.WriteLine("\nBeliebige Taste drücken zum Fortfahren.");
                                Console.ReadKey();
                            }
                            else if (!buchgefunden) // Wenn kein passendes Buch gefunden wurde
                            {
                                Console.WriteLine("\nBuch nicht gefunden.");
                                Console.WriteLine("\nBeliebige Taste drücken zum Fortfahren.");
                                Console.ReadKey();
                            }

                            else // Falls der Benutzer nichts eingegeben hat.
                            {
                                Console.WriteLine("\nLeere Sucheingabe.");
                                Console.WriteLine("\nBeliebige Taste drücken zum Fortfahren.");
                                Console.ReadKey();

                            }
                        } while (false);

                        /*   //alt Variable, um zu prüfen, ob ein passendes Buch gefunden wurde.
                           buchgefunden = false;
                           Console.Clear();
                           Console.Write("Suche nach einem Buch zum zurückgeben: ");
                           suche = Console.ReadLine().ToLower();
                           // Prüft, ob ein Suchbegriff eingegeben wurde.
                           if (!string.IsNullOrEmpty(suche))
                           {
                               for (int i = 0; i < buecher_ausgeliehen.Count; i++)
                               {
                                   //mit Contains wird überprüft ob der Titel des Buches den Suchbegriff enthält
                                   if (buecher_ausgeliehen[i].Titel.ToLower().Contains(suche) && buecher_ausgeliehen[i].Anzahl > 0)
                                   {
                                       buchgefunden = true;
                                       //gefundenes Buch wird angezeigt.
                                       Console.WriteLine("{0,-40} | {1,-26} | {2,-6}", "Buch", "Autor", "Anzahl");
                                       Console.WriteLine("______________________________________________________________________________");
                                       Console.WriteLine("{0,-40} | {1,-26} | {2,-6}", buecher_ausgeliehen[i].Titel, buecher_ausgeliehen[i].Autor, buecher_ausgeliehen[i].Anzahl);
                                       Console.Write("\nWollen sie dieses Buch zurückgeben y/n: ");
                                       string auswahlverschieben = Console.ReadLine();

                                       if (auswahlverschieben.ToLower() == "y")
                                       {
                                           // Das Buch wird in die Inventarliste zurückgegeben. Und gegebenenfalls gelöscht.

                                           for (int j = 0; j < buecher_inventar.Count; j++)
                                           {
                                               // Vergleicht das zurückzugebene Buch mit den bereits Inventar Büchern
                                               if (buecher_inventar[j].Titel == buecher_ausgeliehen[i].Titel && buecher_inventar[j].Autor == buecher_ausgeliehen[i].Autor)
                                               {
                                                   buecher_inventar[j].Anzahl++; // Erhöhe Anzahl

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
                                        Console.WriteLine("{0,-40} | {1,-26}", buecher_ausgeliehen[i].Titel, buecher_ausgeliehen[i].Autor);
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
                        Console.Write("Wie möchten Sie die Liste sortieren? ([T]itel / [A]utor): ");
                        sortWahl = Console.ReadLine();
                        sortWahlstandard = "t"; // Standardmäßig nach Titel sortieren
                        buecher_ausgeliehen = buecher_ausgeliehen.OrderBy(Buch => Buch.Titel).ToList();

                        if (!string.IsNullOrEmpty(sortWahl))
                        {
                            sortWahlstandard = sortWahl.ToLower();
                        }

                        if (sortWahlstandard == "t" || sortWahlstandard == "titel")
                        {
                            // Sortiere die Liste nach Titel
                            buecher_ausgeliehen = buecher_ausgeliehen.OrderBy(Buch => Buch.Titel).ToList();
                            Console.WriteLine("\nAusgeliehene Bücher (sortiert nach Titel):");
                        }

                        else if (sortWahlstandard == "a" || sortWahlstandard == "autor")
                        {
                            // Sortiere die Liste nach Autor
                            buecher_ausgeliehen = buecher_ausgeliehen.OrderBy(Buch => Buch.Autor).ToList();
                            Console.WriteLine("\nAusgeliehene Bücher (sortiert nach Autor):");
                        }

                        if (buecher_ausgeliehen.Count != 0) Buchausgabe(buecher_ausgeliehen);
                        else Console.WriteLine("Es sind keine Bücher ausgeliehen.");

                        // Sortiere die Liste zurück nach Titel    
                        if (sortWahlstandard == "a" || sortWahlstandard == "autor") buecher_ausgeliehen = buecher_ausgeliehen.OrderBy(Buch => Buch.Titel).ToList();

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
                        do
                        {
                            if (!string.IsNullOrEmpty(uiBookRemoveTitel))
                            {
                                List<Buch> loeschen = new List<Buch>();
                                for (int i = 0; i < buecher_inventar.Count; i++)
                                {
                                    if (buecher_inventar[i].Titel.ToLower().Contains(uiBookRemoveTitel))
                                    {
                                        buchgefunden = true;
                                        int j = 0;
                                        loeschen.Add(buecher_inventar[i]);
                                        j++;
                                    }

                                }
                                Buchbearbeitung(loeschen, buecher_inventar, 3);
                                Console.WriteLine("\nBeliebige Taste drücken zum Fortfahren.");
                                Console.ReadKey();

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
                        } while (false);
                        /*//alt
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
                                    Console.WriteLine("{0,-40} | {1,-26}", buecher_inventar[i].Titel, buecher_inventar[i].Autor);
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
                        Console.WriteLine($"{buecher_inventar[index].Autor}");
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

