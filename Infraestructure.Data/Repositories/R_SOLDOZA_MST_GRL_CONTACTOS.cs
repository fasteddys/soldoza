using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data.Model;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Infraestructure.Data.Repositories
{
    public class R_SOLDOZA_MST_GRL_CONTACTOS: ISOLDOZA_MST_GRL_CONTACTOS
    {
        private readonly ApplicationDbContext _context;
        public R_SOLDOZA_MST_GRL_CONTACTOS(ApplicationDbContext context)
        {
            _context = context;
        }

        private string sql;

        public bool Insert(SOLDOZA_MST_GRL_CONTACTOS contact)
        {
            try
            {
                using (var cn = new NpgsqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    cn.Open();
                    sql = @"call sp_contactos_insert(:p_cliente_id, :p_cod_contacto, :p_nombre_contacto, :p_apellidos_contacto, :p_email_contacto, :p_telefono_contacto)";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("p_cliente_id", DbType.Int32).Value = contact.cliente_id;
                    cmd.Parameters.AddWithValue("p_cod_contacto", DbType.String).Value = contact.cod_contacto.ToUpper();
                    cmd.Parameters.AddWithValue("p_nombre_contacto", DbType.String).Value = contact.nombre_contacto.ToUpper();
                    cmd.Parameters.AddWithValue("p_apellidos_contacto", DbType.String).Value = contact.apellidos_contacto.ToUpper();
                    cmd.Parameters.AddWithValue("p_email_contacto", DbType.String).Value = contact.email_contacto.ToLower();
                    cmd.Parameters.AddWithValue("p_telefono_contacto", DbType.String).Value = contact.telefono_contacto;
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

        public bool Update(SOLDOZA_MST_GRL_CONTACTOS contact)
        {
            try
            {
                using (var cn = new NpgsqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    cn.Open();
                    sql = @"call sp_contactos_edit(:p_id, :p_cod_contacto, :p_nombre_contacto, :p_apellidos_contacto, :p_email_contacto, :p_telefono_contacto)";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("p_id", DbType.Int32).Value = contact.id;
                    cmd.Parameters.AddWithValue("p_cod_contacto", DbType.String).Value = contact.cod_contacto.ToUpper();
                    cmd.Parameters.AddWithValue("p_nombre_contacto", DbType.String).Value = contact.nombre_contacto.ToUpper();
                    cmd.Parameters.AddWithValue("p_apellidos_contacto", DbType.String).Value = contact.apellidos_contacto.ToUpper();
                    cmd.Parameters.AddWithValue("p_email_contacto", DbType.String).Value = contact.email_contacto.ToLower();
                    cmd.Parameters.AddWithValue("p_telefono_contacto", DbType.String).Value = contact.telefono_contacto;
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

        public Task<IEnumerable<SOLDOZA_MST_GRL_CONTACTOS>> GetAll(int id)
        {
            var contacts = _context.contactos.Where(c=>c.cliente_id==id);
            return Task.FromResult(contacts.AsEnumerable<SOLDOZA_MST_GRL_CONTACTOS>());
        }

    }
}
