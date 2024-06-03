using Controller;
using Model;
using System.IO;

namespace View
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pressione qualquer tecla para ler os dados no SqlServe e carrega-los no MongoDB");
            Console.ReadKey();
            Executar();
        }

        static void Executar()
        {
            ReadAndPersistController controller = new();

            if (controller.Insert(controller.GetAll()))
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
