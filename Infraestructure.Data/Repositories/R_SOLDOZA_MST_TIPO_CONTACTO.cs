using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data.Model;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructure.Data.Repositories
{
    public class R_SOLDOZA_MST_TIPO_CONTACTO : ISOLDOZA_MST_TIPO_CONTACTO
    {
        private readonly ApplicationDbContext _context;

        public R_SOLDOZA_MST_TIPO_CONTACTO(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SOLDOZA_MST_TIPO_CONTACTO>> GetAll()
        {
            var tipocontactos = _context.tipocontacto;
            return await Task.FromResult(tipocontactos.AsEnumerable<SOLDOZA_MST_TIPO_CONTACTO>());
        }
        //public async Task<IEnumerable<SOLDOZA_MST_TIPO_CONTACTO>> GetAll()
        //{
        //    try
        //    {
        //        using (var cn = new NpgsqlConnection(_context.Database.GetDbConnection().ConnectionString))
        //        {
        //            string sql = "SELECT id, cod_tipo_contacto, descripcion_tipo_contacto FROM soldoza_mst_tipo_contacto";
        //            cn.Open();
        //            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, cn))
        //            {
        //                cmd.CommandType = System.Data.CommandType.Text;
        //                List<SOLDOZA_MST_TIPO_CONTACTO> response = new List<SOLDOZA_MST_TIPO_CONTACTO>();

        //                using (var dr = await cmd.ExecuteReaderAsync())
        //                {
        //                    while (dr.Read())
        //                    {
        //                        SOLDOZA_MST_TIPO_CONTACTO tipocont = new SOLDOZA_MST_TIPO_CONTACTO();

        //                        if (!dr.IsDBNull(dr.GetOrdinal("id")))
        //                            tipocont.id = dr.GetInt32(dr.GetOrdinal("id"));

        //                        if (!dr.IsDBNull(dr.GetOrdinal("cod_tipo_contacto")))
        //                            tipocont.cod_tipo_contacto = dr.GetString(dr.GetOrdinal("cod_tipo_contacto"));

        //                        if (!dr.IsDBNull(dr.GetOrdinal("descripcion_tipo_contacto")))
        //                            tipocont.descripcion_tipo_contacto = dr.GetString(dr.GetOrdinal("descripcion_tipo_contacto"));

        //                        response.Add(tipocont);
        //                    }
        //                }

        //                return (IEnumerable<SOLDOZA_MST_TIPO_CONTACTO>)response;
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
