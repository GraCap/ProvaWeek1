using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaGC.Classi
{
    class Spesa
    {
        public static List<Spesa> loadShopping = new List<Spesa>();
        public   string Data { get; set; }
        public   string Categoria { get; set; }
        public   string Descrizione { get; set; }
        public   decimal Importo { get; set; }

        public static string DataStatic { get; set; }
        public static string CategoriaStatic { get; set; }
        public static string DescrizioneStatic { get; set; }
        public static decimal ImportoStatic { get; set; }

        public Spesa(string data, string categoria, string descrizione, decimal importo)
        {
            Data = data;
            Categoria = categoria;
            Descrizione = descrizione;
            Importo = importo;
        }

        public string Info()
        {
            return $"{Data};{Categoria};{Descrizione};{Importo}";
        }

        public string InfoElaborate()
        {
            return $"{Data};{Categoria};{Descrizione};APPROVATA;{Importo}";
        }

        public string InfoSpesaRespinta()
        {
            return $"{Data};{Categoria};{Descrizione};RESPINTA;-;-";
        }



        public void SaveToFile(string fileName)
        {
            try
            {
                using StreamWriter writer = File.AppendText(@"C:\Users\graziella.caputo\Desktop\PROVA\ProvaGC\" + fileName);
                writer.WriteLine(Info());
                writer.Close();
            } 
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SaveToFileElab(string fileName)
        {
            try
            {
                using StreamWriter writer = File.AppendText(@"C:\Users\graziella.caputo\Desktop\PROVA\ProvaGC\" + fileName);
                writer.WriteLine(InfoElaborate());
                writer.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void SaveToFileRespinta(string fileName)
        {
            try
            {
                using StreamWriter writer = File.AppendText(@"C:\Users\graziella.caputo\Desktop\PROVA\ProvaGC\" + fileName);
                writer.WriteLine(InfoSpesaRespinta());
                writer.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void HandleNewTextFile(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Un nuovo file è stato creato {e.Name}");
            try
            {
                //Lettura del file creato 
                using StreamReader reader = File.OpenText(e.FullPath);
                Console.WriteLine($"--- Lettura di {e.Name} ---");
                
                string[] dati = reader.ReadLine().Split(";");       //suddivide i valori correttamente così da passarli come parametri al costruttore
                DataStatic = dati[0];
                CategoriaStatic = dati[1];
                DescrizioneStatic = dati[2];
                bool resultOK = decimal.TryParse(dati[3], out decimal x);
                if (resultOK)
                    ImportoStatic = x;

                reader.Close();
            }
            catch (IOException exp)
            {
                Console.WriteLine(exp.Message);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
            finally //Viene sempre eseguito ogni volta che viene recuperato un item così il valore del campo viene subito instanziato per creare un nuovo oggetto
            {
                Spesa spesa = new Spesa(DataStatic, CategoriaStatic, DescrizioneStatic, ImportoStatic);
                loadShopping.Add(spesa);        //viene inserito nella lista di elementi caricati da file
            }
        }
    }
}
