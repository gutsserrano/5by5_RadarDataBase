using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Model
{
    public class DataConverter
    {
        public static List<Radar>? GetData(string path)
        {
            StreamReader sr = new(path);
            string jsonString = sr.ReadToEnd();

            var settings = new JsonSerializerSettings
            {
                Culture = new CultureInfo("pt-BR"),
                DateFormatString = "dd/MM/yyyy"
            };


            var list = JsonConvert.DeserializeObject<ListaRadares>(jsonString, settings);

            if (list != null) return list.ListaDeRadares;
            return null;
        }
    }
}
