using Microsoft.Data.SqlClient;
using Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SqlRepository : FileGeneratorRepository
    {
        private readonly string _strSqlConn = "Data Source=127.0.0.1; Initial Catalog=DBRadar; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes";
        SqlConnection sqlConn;

        public SqlRepository()
        {
            sqlConn = new SqlConnection(_strSqlConn);
        }

        public override List<Radar> GetAll()
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
    }
}
