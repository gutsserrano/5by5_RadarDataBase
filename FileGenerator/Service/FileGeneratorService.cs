using Model;
using Repository;

namespace Service
{
    public class FileGeneratorService : IManageData
    {
        private FileGeneratorRepository _repository;

        public FileGeneratorService(FileGeneratorRepository repo)
        {
            _repository = repo;
        }

        public List<Radar> GetAll()
        {
            return _repository.GetAll();
        }

        public bool Insert(List<Radar> lst)
        {
            return _repository.Insert(lst);
        }

        public bool Delete(Radar radar)
        {
            return _repository.Delete(radar);
        }

        public Radar Get(int id)
        {
            return _repository.Get(id);
        }

        public bool Update(Radar radar)
        {
            return _repository.Update(radar);
        }
    }
}
