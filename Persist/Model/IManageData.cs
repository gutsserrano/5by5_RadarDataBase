using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IManageData
    {
        public bool Insert(List<Radar> lst);

        public bool Update(Radar radar);

        public bool Delete(Radar radar);

        public List<Radar> GetAll();

        public Radar Get(int id);
    }
}
