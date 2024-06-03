using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RadarService : IManageData
    {
        private RadarRepository _radarRepository;

        public RadarService()
        {
            _radarRepository = new RadarRepository();
        }

        public bool Delete(Radar radar)
        {
            return _radarRepository.Delete(radar);
        }

        public Radar Get(int id)
        {
            return (Radar)_radarRepository.Get(id);
        }

        public List<Radar> GetAll()
        {
            return _radarRepository.GetAll();
        }

        public bool Insert(List<Radar> lst)
        {
            return _radarRepository.Insert(lst);
        }

        public bool Update(Radar radar)
        {
            return _radarRepository.Update(radar);
        }
    }
}
