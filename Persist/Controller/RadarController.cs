using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class RadarController : IManageData
    {
        private RadarService _radarService;

        public RadarController()
        {
            _radarService = new RadarService();
        }

        public bool Delete(Radar radar)
        {
            return _radarService.Delete(radar);
        }

        public Radar Get(int id)
        {
            return _radarService.Get(id);
        }

        public List<Radar> GetAll()
        {
            return _radarService.GetAll();
        }

        public bool Insert(List<Radar> lst)
        {
            return _radarService.Insert(lst);
        }

        public bool Update(Radar radar)
        {
            return _radarService.Update(radar);
        }
    }
}
