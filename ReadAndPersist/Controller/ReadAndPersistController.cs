using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ReadAndPersistController : IManageData
    {
        private ReadAndPersistService _service;

        public ReadAndPersistController()
        {
            _service = new ReadAndPersistService();
        }

        public bool Insert(List<Radar> lst)
        {
            return _service.Insert(lst);
        }

        public List<Radar> GetAll()
        {
            return _service.GetAll();
        }

        public bool Delete(Radar radar)
        {
            return _service.Delete(radar);
        }

        public Radar Get(int id)
        {
            return _service.Get(id);
        }

        public bool Update(Radar radar)
        {
            return _service.Update(radar);
        }
    }   
    {
    }
}
