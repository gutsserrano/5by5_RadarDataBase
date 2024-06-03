using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;

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

        public static string toCSV(List<Radar> list)
        {
            var csv = new StringBuilder();
            foreach (var item in list)
            {
                csv.AppendLine($"{item.Id};" +
                    $"{item.Concessionaria};" +
                    $"{item.AnoDoPnvSnv};" +
                    $"{item.TipoRadar};" +
                    $"{item.Rodovia};" +
                    $"{item.Uf};" +
                    $"{item.Km};" +
                    $"{item.Municipio};" +
                    $"{item.TipoPista};" +
                    $"{item.Sentido};" +
                    $"{item.Situacao};" +
                    $"{item.DataInativacao};"+
                    $"{item.Latitude};" +
                    $"{item.Longitude};" +
                    $"{item.VelocidadeLeve};");
            }

            return csv.ToString();
        }

        public static string toXML(List<Radar> list)
        {
            if(list.Count > 0)
            {
                var listaRadares = new XElement("ListaDeRadares", from r in list
                                                                    select new XElement("Radar",
                                                                        new XElement("Id", r.Id),
                                                                        new XElement("Concessionaria", r.Concessionaria),
                                                                        new XElement("AnoDoPnvSnv", r.AnoDoPnvSnv),
                                                                        new XElement("TipoRadar", r.TipoRadar),
                                                                        new XElement("Rodovia", r.Rodovia),
                                                                        new XElement("Uf", r.Uf),
                                                                        new XElement("Km", r.Km),
                                                                        new XElement("Municipio", r.Municipio),
                                                                        new XElement("TipoPista", r.TipoPista),
                                                                        new XElement("Sentido", r.Sentido),
                                                                        new XElement("Situacao", r.Situacao),
                                                                        new XElement("Latitude", r.Latitude),
                                                                        new XElement("Longitude", r.Longitude),
                                                                        new XElement("VelocidadeLeve", r.VelocidadeLeve),
                                                                        new XElement("DataInativacao", r.DataInativacao)
                                                                        )
                                                    );
                return listaRadares.ToString();
            }

            return "";
        }

        public static string ToJson(List<Radar> list)
        {
            return JsonConvert.SerializeObject(list);
        }
    }
}
