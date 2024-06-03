using Model;
using Repository;
using Controller;
using Service;
namespace View
{
    public class Program
    {
        static void Main(string[] args)
        {
            FileGeneratorController controller = new FileGeneratorController(new FileGeneratorService(new MongoRepository()));

            List<Radar> lst = controller.GetAll();

            Console.WriteLine(DataConverter.toCSV(lst));
            Console.WriteLine(DataConverter.ToJson(lst));
            Console.WriteLine(DataConverter.toXML(lst));
        }
    }
}
