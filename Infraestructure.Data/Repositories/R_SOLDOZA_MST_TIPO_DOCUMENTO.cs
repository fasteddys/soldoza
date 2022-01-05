using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data.Model;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructure.Data.Repositories
{
    public class R_SOLDOZA_MST_TIPO_DOCUMENTO: ISOLDOZA_MST_TIPO_DOCUMENTO
    {
        private readonly ApplicationDbContext _context;

        public R_SOLDOZA_MST_TIPO_DOCUMENTO(ApplicationDbContext context)
        {
            _context = context;
        }        
        public async Task<IEnumerable<SOLDOZA_MST_TIPO_DOCUMENTO>> GetAll()
        {
            try
            {
                using (var cn = new NpgsqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    string sql = "SELECT id, descripcion_tipo_documento, abrev_tipo_documento FROM SOLDOZA_MST_TIPO_DOCUMENTO";
                    cn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, cn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        List<SOLDOZA_MST_TIPO_DOCUMENTO> response = new List<SOLDOZA_MST_TIPO_DOCUMENTO>();

                        using (var dr = await cmd.ExecuteReaderAsync())
                        {
                            while (dr.Read())
                            {
                                SOLDOZA_MST_TIPO_DOCUMENTO tipodoc = new SOLDOZA_MST_TIPO_DOCUMENTO();

                                if (!dr.IsDBNull(dr.GetOrdinal("id")))
                                    tipodoc.id = dr.GetInt32(dr.GetOrdinal("id"));

                                if (!dr.IsDBNull(dr.GetOrdinal("descripcion_tipo_documento")))
                                    tipodoc.descripcion_tipo_documento = dr.GetString(dr.GetOrdinal("descripcion_tipo_documento"));

                                if (!dr.IsDBNull(dr.GetOrdinal("abrev_tipo_documento")))
                                    tipodoc.abrev_tipo_documento = dr.GetString(dr.GetOrdinal("abrev_tipo_documento"));

                                response.Add(tipodoc);
                            }
                        }

                        return (IEnumerable<SOLDOZA_MST_TIPO_DOCUMENTO>)response;
                    }
                }
            }

            catch
            {
                return null;
            }
        }

    }
}
