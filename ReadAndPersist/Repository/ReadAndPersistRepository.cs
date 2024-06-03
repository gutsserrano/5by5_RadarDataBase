using Microsoft.Data.SqlClient;
using Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ReadAndPersistRepository : IManageData
    {
        private readonly string _strSqlConn = "Data Source=127.0.0.1; Initial Catalog=DBRadar; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes";
        SqlConnection sqlConn;

        private readonly string _mongoConn = "mongodb://root:Mongo%402024%23@localhost:27017/";
        MongoClient Client;

        public ReadAndPersistRepository()
        {
            sqlConn = new SqlConnection(_strSqlConn);
            Client = new MongoClient(_mongoConn);
        }

        public bool Insert(List<Radar> lst)
        {
            IMongoCollection<BsonDocument> collection;

            var database = Client.GetDatabase("DBRadar");
            collection = database.GetCollection<BsonDocument>("Radar");

            foreach (var r in lst)
            {
                var document = new BsonDocument
                {
                    { "id", r.Id },
                    { "concessionaria", r.Concessionaria },
                    { "ano_do_pnv_snv", r.AnoDoPnvSnv },
                    { "tipo_de_radar", r.TipoRadar },
                    { "rodovia", r.Rodovia },
                    { "uf", r.Uf },
                    { "km_m", r.Km },
                    { "municipio", r.Municipio },
                    { "tipo_pista", r.TipoPista },
                    { "sentido", r.Sentido },
                    { "situacao", r.Situacao },
                    { "data_da_inativacao", string.Join(",", r.DataInativacao) },
                    { "latitude", r.Latitude },
                    { "longitude", r.Longitude },
                    { "velocidade_leve", r.VelocidadeLeve }
                };
                collection.InsertOne(document);
            }
            return true;
        }

        public List<Radar> GetAll()
        {
            var cmd = new SqlCommand("SELECT * FROM Radar", sqlConn);

            List<Radar> lista = null;
            try
            {
                sqlConn.Open();

                using var reader = cmd.ExecuteReader();
                lista = new List<Radar>();

                while (reader.Read())
                {
                    var r = new Radar
                    {
                        Id = int.Parse(reader["id"].ToString()),
                        Concessionaria = reader["concessionaria"].ToString(),
                        AnoDoPnvSnv = int.Parse(reader["ano_do_pnv_snv"].ToString()),
                        TipoRadar = reader["tipo_de_radar"].ToString(),
                        Rodovia = reader["rodovia"].ToString(),
                        Uf = reader["uf"].ToString(),
                        Km = reader["km_m"].ToString(),
                        Municipio = reader["municipio"].ToString(),
                        TipoPista = reader["tipo_pista"].ToString(),
                        Sentido = reader["sentido"].ToString(),
                        Situacao = reader["situacao"].ToString(),
                        Latitude = double.Parse(reader["latitude"].ToString()),
                        Longitude = double.Parse(reader["longitude"].ToString()),
                        VelocidadeLeve = int.Parse(reader["velocidade_leve"].ToString())
                    };

                    if (DateOnly.TryParse(reader["data_da_inativacao"].ToString(), out _) == false)
                        r.DataInativacao = new DateTime[] { };
                    else
                        r.DataInativacao = new DateTime[] { DateTime.Parse(reader["data_da_inativacao"].ToString()) };

                    lista.Add(r);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            finally
            {
                sqlConn.Close();
            }

            return lista;
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
