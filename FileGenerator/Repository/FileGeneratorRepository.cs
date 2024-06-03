using Model;

namespace Repository
{
    public abstract class FileGeneratorRepository : IManageData
    {
        public abstract List<Radar> GetAll();

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
