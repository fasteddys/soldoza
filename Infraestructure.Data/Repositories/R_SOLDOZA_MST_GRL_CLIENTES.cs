using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data;
using Infraestructure.Data.Model;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructure.Data.Repositories
{
    public class R_SOLDOZA_MST_GRL_CLIENTES: ISOLDOZA_MST_GRL_CLIENTES
    {
        private readonly ApplicationDbContext _context;
        public R_SOLDOZA_MST_GRL_CLIENTES(ApplicationDbContext context)
        {
            _context = context;
        }

        private string sql;
        
        public void Insert(SOLDOZA_MST_GRL_CLIENTES customer)
        {

            try
            {
                using (var cn = new NpgsqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    cn.Open();
                    sql = @"INSERT INTO soldoza_mst_grl_clientes(cod_cliente, tipo_documento_ID, nrodoc_cliente, nombre_cliente, direccion_cliente, " +
                                                            "pais, ciudad, telefono, email, usuario_creacion, fecha_creacion, usuario_actualizacion, " +
                                                            "fecha_actualizacion, estado) VALUES('" + customer.cod_cliente.ToUpper() + "'," +
                                                            customer.tipo_documento_id + ",'" + customer.nrodoc_cliente + "','" +
                                                            customer.nombre_cliente.ToUpper() + "','" + customer.direccion_cliente.ToUpper() + "','" +
                                                            customer.pais.ToUpper() + "','" + customer.ciudad.ToUpper() + "','" +
                                                            customer.telefono + "','" + customer.email + "','" + customer.usuario_creacion + "'," +
                                                            "CURRENT_TIMESTAMP, NULL, NULL, 'N')";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.ExecuteNonQuery();
                    cn.Close();

                }
            }
            catch
            {
            }
        }

        public void Update(SOLDOZA_MST_GRL_CLIENTES customer)
        {
            using (var cn = new NpgsqlConnection(_context.Database.GetDbConnection().ConnectionString))
            {
                cn.Open();

                sql = @"UPDATE soldoza_mst_grl_clientes SET cod_cliente ='" + customer.cod_cliente.ToUpper() + "'," +
                                                           "tipo_documento_ID =" + customer.tipo_documento_id + "," +
                                                           "nrodoc_cliente ='" + customer.nrodoc_cliente + "'," +
                                                           "nombre_cliente ='" + customer.nombre_cliente.ToUpper() + "'," +
                                                           "direccion_cliente ='" + customer.direccion_cliente.ToUpper() + "'," +
                                                           "pais ='" + customer.pais.ToUpper() + "'," +
                                                           "ciudad ='" + customer.ciudad.ToUpper() + "'," +
                                                           "telefono ='" + customer.telefono + "'," +
                                                           "email ='" + customer.email.ToLower() + "'," +
                                                           "usuario_actualizacion ='" + customer.usuario_actualizacion + "'," +
                                                           "fecha_actualizacion = CURRENT_TIMESTAMP " +
                                                           "WHERE id =" + customer.id;
                NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }

        public async Task<IEnumerable<SOLDOZA_MST_GRL_CLIENTES>> GetAll()
        {
            try
            {
                using (var cn = new NpgsqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    string sql = "SELECT id, cod_cliente, tipo_documento_id, nrodoc_cliente, nombre_cliente, direccion_cliente, pais, ciudad, telefono, email " +
                                 "FROM SOLDOZA_MST_GRL_CLIENTES";
                    cn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, cn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        List<SOLDOZA_MST_GRL_CLIENTES> response = new List<SOLDOZA_MST_GRL_CLIENTES>();

                        using (var dr = await cmd.ExecuteReaderAsync())
                        {
                            while (dr.Read())
                            {
                                SOLDOZA_MST_GRL_CLIENTES cliente = new SOLDOZA_MST_GRL_CLIENTES();

                                if (!dr.IsDBNull(dr.GetOrdinal("id")))
                                    cliente.id = dr.GetInt32(dr.GetOrdinal("id"));

                                if (!dr.IsDBNull(dr.GetOrdinal("cod_cliente")))
                                    cliente.cod_cliente = dr.GetString(dr.GetOrdinal("cod_cliente"));

                                if (!dr.IsDBNull(dr.GetOrdinal("tipo_documento_id")))
                                    cliente.tipo_documento_id = dr.GetInt32(dr.GetOrdinal("tipo_documento_id"));

                                if (!dr.IsDBNull(dr.GetOrdinal("nrodoc_cliente")))
                                    cliente.nrodoc_cliente = dr.GetString(dr.GetOrdinal("nrodoc_cliente"));

                                if (!dr.IsDBNull(dr.GetOrdinal("nombre_cliente")))
                                    cliente.nombre_cliente = dr.GetString(dr.GetOrdinal("nombre_cliente"));                              

                                if (!dr.IsDBNull(dr.GetOrdinal("direccion_cliente")))
                                    cliente.direccion_cliente = Convert.ToString(dr.GetString(dr.GetOrdinal("direccion_cliente")));

                                if (!dr.IsDBNull(dr.GetOrdinal("pais")))
                                    cliente.pais = Convert.ToString(dr.GetString(dr.GetOrdinal("pais")));

                                if (!dr.IsDBNull(dr.GetOrdinal("ciudad")))
                                    cliente.ciudad = Convert.ToString(dr.GetString(dr.GetOrdinal("ciudad")));

                                if (!dr.IsDBNull(dr.GetOrdinal("telefono")))
                                    cliente.telefono = Convert.ToString(dr.GetString(dr.GetOrdinal("telefono")));

                                if (!dr.IsDBNull(dr.GetOrdinal("email")))
                                    cliente.email = Convert.ToString(dr.GetString(dr.GetOrdinal("email")));

                                response.Add(cliente);
                            }
                        }

                        return (IEnumerable<SOLDOZA_MST_GRL_CLIENTES>)response;
                    }
                }
            }

            catch
            {
                return null;
            }
        }


        public IEnumerable<SOLDOZA_MST_GRL_CLIENTES> GetAll2()
        {
            return _context.clientes.Include(c => c.tipodocumento);
        }

        public Task<SOLDOZA_MST_GRL_CLIENTES> GetCustomer(int id)
        {
            return _context.clientes.Include(c => c.tipodocumento).Where(c => c.id == id).FirstOrDefaultAsync();
        }


    }
}
