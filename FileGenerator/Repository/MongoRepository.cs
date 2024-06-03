using Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MongoRepository : FileGeneratorRepository
    {
        private readonly string _mongoConn = "mongodb://root:Mongo%402024%23@localhost:27017/";
        MongoClient Client;

        public MongoRepository()
        {
            Client = new MongoClient(_mongoConn);
        }

        public override List<Radar> GetAll()
        {
            var database = Client.GetDatabase("DBRadar");
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("Radar");

            List<Radar> lista = new List<Radar>();

            try
            {
                var documents = collection.AsQueryable();

                foreach (var item in documents)
                {
                    var r = new Radar
                    {
                        Id = (int)item.GetValue("id", 0),
                        Concessionaria = (string)item.GetValue("concessionaria", ""),
                        AnoDoPnvSnv = (int)item.GetValue("ano_do_pnv_snv", 0),
                        TipoRadar = (string)item.GetValue("tipo_de_radar", ""),
                        Rodovia = (string)item.GetValue("rodovia", ""),
                        Uf = (string)item.GetValue("uf", ""),
                        Km = (string)item.GetValue("km_m", ""),
                        Municipio = (string)item.GetValue("municipio", ""),
                        TipoPista = (string)item.GetValue("tipo_pista", ""),
                        Sentido = (string)item.GetValue("sentido", ""),
                        Situacao = (string)item.GetValue("situacao", ""),
                        DataInativacao = null,//Array.Empty<DateTime>(),
                        Latitude = (double)item.GetValue("latitude", 0.0),
                        Longitude = (double)item.GetValue("longitude", 0.0),
                        VelocidadeLeve = (int)item.GetValue("velocidade_leve", 0),
                    };
                    lista.Add(r);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
                throw;
            }
            return lista;
        }
    }
}
