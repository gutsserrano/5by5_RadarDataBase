using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ListaRadares
    {
        [JsonProperty("radar")]
        public List<Radar> ListaDeRadares { get; set; }
    }
}
