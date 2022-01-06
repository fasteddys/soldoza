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
    public class R_SOLDOZA_MST_MATERIALES : ISOLDOZA_MST_MATERIALES
    {
        private readonly ApplicationDbContext _context;
        public R_SOLDOZA_MST_MATERIALES(ApplicationDbContext context)
        {
            _context = context;
        }

        private string sql;
        public Task<IEnumerable<SOLDOZA_MST_MATERIALES>> GetAll()
        {
            var materiales = _context.materiales;
            return Task.FromResult(materiales.AsEnumerable<SOLDOZA_MST_MATERIALES>());
        }

       
        public bool Insert(SOLDOZA_MST_MATERIALES material)
        {
            try
            {
                //using (var cn = new NpgsqlConnection(_context.Database.GetDbConnection().ConnectionString))
                //{
                //    cn.Open();
                //    sql = @"call sp_materiales_insert(:p_cod_material, :p_descripcion_material, :p_p_num, :p_g_num)";
                //    NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);
                //    cmd.Parameters.AddWithValue("p_cod_material", DbType.String).Value = material.cod_material.ToUpper();
                //    cmd.Parameters.AddWithValue("p_descripcion_material", DbType.String).Value = material.descripcion_material.ToUpper();
                //    cmd.Parameters.AddWithValue("p_p_num", DbType.Int32).Value = material.p_num.ToUpper();
                //    cmd.Parameters.AddWithValue("p_g_num", DbType.String).Value = material.g_num.ToUpper();
                //    cmd.CommandType = System.Data.CommandType.Text;
                //    cmd.ExecuteNonQuery();
                //    return true;

                //}

                if (material == null)
                {
                    return false;
                }

                _context.Add(material);
                _context.SaveChanges(true);
                return true;


            }
            catch
            {
                return false;
            }
        }

        public bool Update(SOLDOZA_MST_MATERIALES material)
        {
            try
            {
                if (material == null)
                {
                    return false;
                }

                _context.Update(material);
                _context.SaveChanges(true);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
