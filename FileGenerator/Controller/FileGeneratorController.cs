using Model;
using Service;

namespace Controller
{
    public class FileGeneratorController : IManageData
    {
        private FileGeneratorService _service;

        public FileGeneratorController(FileGeneratorService service)
        {
            _service = service;
        }

        public List<Radar> GetAll()
        {
            return _service.GetAll();
        }

        public bool Insert(List<Radar> lst)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Radar radar)
        {
            throw new NotImplementedException();
        }

        public Radar Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Radar radar)
        {
            throw new NotImplementedException();
        }
    }
}
