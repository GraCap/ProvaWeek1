using System;
using System.Collections.Generic;
using System.IO;
using ProvaGC.Classi;
using ProvaGC.Classi_Factory;

namespace ProvaGC
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();   

            //Directory monitorata
            watcher.Path = @"C:\Users\graziella.caputo\Desktop\PROVA\ProvaGC";

            //File d'interesse
            watcher.Filter = "*.txt";

            //Notifico l'evento in cui venga creato il file d'interesse
            watcher.NotifyFilter = NotifyFilters.CreationTime 
                                    | NotifyFilters.LastWrite
                                    | NotifyFilters.FileName
                                    | NotifyFilters.DirectoryName
                                    | NotifyFilters.LastAccess;

            //Abilito notifiche
            watcher.EnableRaisingEvents = true;

            //Istanzio oggetti di tipo spesa
            Spesa spesa1 = new Spesa("2020/12/3", "Viaggio", "Roma-Milano", 50);
            Spesa spesa2 = new Spesa("2020/7/9", "Alloggio", "Hotel Eden", 250);
            Spesa spesa3 = new Spesa("2020/7/9", "Vitto", "Pranzo", 34);
            Spesa spesa4 = new Spesa("2020/7/9", "Viaggio", "Roma-Berlino", 350);
            Spesa spesa5 = new Spesa("2020/8/10", "Altro", "Acquisti Personali", 3000);
            Spesa spesa6 = new Spesa("2021/7/9", "Alloggio", "Hotel Luxury", 1500);
            Spesa spesa7 = new Spesa("2021/7/9", "Vitto", "Cena", 500);
            //Creo una lista con le spese effettuate

            List<Spesa> list = new List<Spesa>();

            list.Add(spesa1); 
            list.Add(spesa2); 
            list.Add(spesa3); 
            list.Add(spesa4); 
            list.Add(spesa5); 
            list.Add(spesa6);
            list.Add(spesa7);

            //Scrivo su file tutte le spese effettuate
            foreach (Spesa sp in list)
            {
                sp.SaveToFile("spese.txt");
            }
            //Al momento della creazione gestisco l'evento che apre e legge il file
            watcher.Created += Spesa.HandleNewTextFile;
            watcher.Changed += Spesa.HandleNewTextFile;



            Console.WriteLine("Chain of Responsibility");

            var ceo = new CEO();
            var manager = new Manager();
            var operationalManager = new OperationalManager();

            //Catena di responsabilità 
            manager.SetNext(operationalManager).SetNext(ceo);
            

            foreach (Spesa s in Spesa.loadShopping)
            {
                Console.WriteLine($"Importo {s} approvato?");
                var result = manager.Handle(s.Importo);       //invio della richiesta

                //gestione del risultato
                if (result)
                {
                    //USO IL FACTORY PATTERN
                    //se viene restituito true quindi la spesa è stata approvata perchè l'importo non superiore a 2500
                    ICategory tipoSpesa = Factory.FactoryFunction(s.Categoria, s.Importo);
                    s.SaveToFileElab("spese_elaborate.txt");
                    Console.WriteLine(tipoSpesa.CalcoloRimborso(s.Importo));
                }
                else
                    s.SaveToFileRespinta("spese_elaborate.txt");
                    Console.WriteLine($"Importo {s.Importo} non approvato!");
            }



            Console.WriteLine("Inserisci q per chudere il programma");
            while (Console.Read() != 'q') ;
        }

       
    }
}
