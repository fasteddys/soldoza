using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data.Model;
using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructure.Data.Repositories
{
    public class R_SOLDOZA_MST_PAIS: ISOLDOZA_MST_PAIS
    {
        private readonly ApplicationDbContext _context;

        public R_SOLDOZA_MST_PAIS(ApplicationDbContext context)
        {
            _context = context;
        }


        string cnn = "Server=localhost; Database=dbsoldoza; User Id=postgres; Password=admin;"; //_configuration["Connnectionstrings:MyConnection"];

        public IEnumerable<SOLDOZA_MST_PAIS> GetAll()
        {

            return _context.paises;
      
        }
        //public async Task<IEnumerable<SOLDOZA_MST_PAIS>> GetAll()
        //{
        //    try
        //    {
        //        using (var cn = new NpgsqlConnection(cnn))
        //        {
        //            string sql = "SELECT id, nombre_pais FROM SOLDOZA_MST_PAIS";
        //            cn.Open();
        //            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, cn))
        //            {
        //                cmd.CommandType = System.Data.CommandType.Text;
        //                List<SOLDOZA_MST_PAIS> response = new List<SOLDOZA_MST_PAIS>();

        //                using (var dr = await cmd.ExecuteReaderAsync())
        //                {
        //                    while (dr.Read())
        //                    {
        //                        SOLDOZA_MST_PAIS pais = new SOLDOZA_MST_PAIS();

        //                        if (!dr.IsDBNull(dr.GetOrdinal("id")))
        //                            pais.id = dr.GetInt32(dr.GetOrdinal("id"));

        //                        if (!dr.IsDBNull(dr.GetOrdinal("nombre_pais")))
        //                            pais.nombre_pais = dr.GetString(dr.GetOrdinal("nombre_pais"));

        //                        response.Add(pais);
        //                    }
        //                }

        //                return (IEnumerable<SOLDOZA_MST_PAIS>)response;
        //            }
        //        }
        //    }

        //    catch
        //    {
        //        return null;
        //    }
        //}
    }
}
