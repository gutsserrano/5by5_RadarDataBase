using Controller;

namespace View
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadAndPersistController controller = new();

            controller.Insert(controller.GetAll());
        }
    }
}
