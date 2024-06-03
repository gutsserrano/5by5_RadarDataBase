using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ReadAndPersistService : IManageData
    {
        private ReadAndPersistRepository _repository;

        public ReadAndPersistService()
        {
            _repository = new ReadAndPersistRepository();
        }

        public bool Insert(List<Radar> lst)
        {
            return _repository.Insert(lst);
        }

        public List<Radar> GetAll()
        {
            return _repository.GetAll();
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
