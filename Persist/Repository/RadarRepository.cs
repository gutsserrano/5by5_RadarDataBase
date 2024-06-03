using Microsoft.Data.SqlClient;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RadarRepository : IManageData
    {
        private readonly string _strConn = "Data Source=127.0.0.1; Initial Catalog=DBRadar; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=Yes";
        SqlConnection conn;

        public RadarRepository()
        {
            conn = new SqlConnection(_strConn);
        }
        public bool Insert(List<Radar> lst)
        {
            //SqlCommand cmd = new SqlCommand();
            bool result = true;


            foreach (var item in lst)
            {
                string values = "INSERT INTO Radar VALUES (@concessionaria, @ano_do_pnv_snv, @tipo_de_radar, @rodovia, @uf, " +
               "@km_m, @municipio, @tipo_pista, @sentido, @situacao, @data_da_inativacao," +
               " @latitude, @longitude, @velocidade_leve)";

                using var cmd = new SqlCommand(values, conn)
                {
                    Parameters =
                    {
                        new SqlParameter("@concessionaria", item.Concessionaria),
                        new SqlParameter("@ano_do_pnv_snv", item.AnoDoPnvSnv),
                        new SqlParameter("@tipo_de_radar", item.TipoRadar),
                        new SqlParameter("@rodovia", item.Rodovia),
                        new SqlParameter("@uf", item.Uf),
                        new SqlParameter("@km_m", item.Km),
                        new SqlParameter("@municipio", item.Municipio),
                        new SqlParameter("@tipo_pista", item.TipoPista),
                        new SqlParameter("@sentido", item.Sentido),
                        new SqlParameter("@situacao", item.Situacao),
                        new SqlParameter("@latitude", item.Latitude),
                        new SqlParameter("@longitude", item.Longitude),
                        new SqlParameter("@velocidade_leve", item.VelocidadeLeve)
            }
                };

                if (item.DataInativacao.Length != 0)
                    cmd.Parameters.Add(new SqlParameter("@data_da_inativacao", item.DataInativacao[0]));
                else
                    cmd.Parameters.Add(new SqlParameter("@data_da_inativacao", DBNull.Value));

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERRO: " + e);
                    result = false;
                    break;
                }
                finally
                {
                    conn.Close();
                }
            }
            
            return result;
        }

        public bool Update(Radar radar)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Radar radar)
        {
            throw new NotImplementedException();
        }

        public Radar Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Radar> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
