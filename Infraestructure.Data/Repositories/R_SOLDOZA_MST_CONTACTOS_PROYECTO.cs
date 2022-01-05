using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data.Model;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data.Repositories
{
    public class R_SOLDOZA_MST_CONTACTOS_PROYECTO : ISOLDOZA_MST_CONTACTOS_PROYECTO
    {
        private readonly ApplicationDbContext _context;
        public R_SOLDOZA_MST_CONTACTOS_PROYECTO(ApplicationDbContext context)
        {
            _context = context;
        }

        private string sql;
        public bool Delete(SOLDOZA_MST_CONTACTOS_PROYECTO contact)
        {
            try
            {
                using (var cn = new NpgsqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    cn.Open();
                    sql = @"call sp_contacto_proyecto_delete(:p_contacto_id, :p_proyecto_id)";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("p_contacto_id", DbType.Int32).Value = contact.contacto_id;
                    cmd.Parameters.AddWithValue("p_proyecto_id", DbType.Int32).Value = contact.proyecto_id;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public Task<IEnumerable<SOLDOZA_MST_CONTACTOS_PROYECTO>> GetAll(int id)
        {
            var contacts = _context.contactosproyecto.Where(c => c.proyecto_id == id).Include(c=>c.contacto).Include(c=>c.tipocontacto);
            return Task.FromResult(contacts.AsEnumerable<SOLDOZA_MST_CONTACTOS_PROYECTO>());
        }

        public bool Insert(SOLDOZA_MST_CONTACTOS_PROYECTO contact)
        {
            try
            {
                using (var cn = new NpgsqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    cn.Open();
                    sql = @"call sp_contacto_proyecto_insert(:p_contacto_id, :p_proyecto_id, :p_tipo_contacto_id)";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("p_contacto_id", DbType.Int32).Value = contact.contacto_id;
                    cmd.Parameters.AddWithValue("p_proyecto_id", DbType.Int32).Value = contact.proyecto_id;
                    cmd.Parameters.AddWithValue("p_tipo_contacto_id", DbType.Int32).Value = contact.tipo_contacto_id;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.ExecuteNonQuery();
                    return true;

                }
            }
            catch
            {
                return false;
            }
        }
    }
}
