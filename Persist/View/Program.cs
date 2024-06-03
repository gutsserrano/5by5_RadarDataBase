using Controller;
using Model;

namespace View
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pressione qualquer tecla para ler os dados JSON e carrega-los no SqlServer");
            Console.ReadKey();
            Inserir();
        }

        static void Inserir()
        {
            Console.Clear(); 
            Console.WriteLine("Aguarde...");
            string path = "C:\\RadarArchives\\dados_dos_radares.json";
            RadarController radarController = new();

            if (radarController.Insert(DataConverter.GetData(path)))
            {
                Console.Clear();
                Console.WriteLine("Dados inseridos com sucesso");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Falha ao inserir dados");
            }
        }
    }
}
