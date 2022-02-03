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
    public class R_SOLDOZA_MST_GRL_PROYECTOS : ISOLDOZA_MST_GRL_PROYECTOS
    {
        private readonly ApplicationDbContext _context;
        public R_SOLDOZA_MST_GRL_PROYECTOS(ApplicationDbContext context)
        {
            _context = context;
        }

        private string sql;
        public Task<IEnumerable<SOLDOZA_MST_GRL_PROYECTOS>> GetProjects(int id)
        {
            var projects = _context.proyectos.Include(p=>p.versiones)
                                             .Include(p=>p.planos)
                                             .Include(p=>p.contactos).ThenInclude(cs=>cs.contacto)
                                             .Include(p=>p.contactos).ThenInclude(cs=>cs.tipocontacto)
                                             .Where(p=>p.cliente_id==id);
            return Task.FromResult(projects.AsEnumerable<SOLDOZA_MST_GRL_PROYECTOS>());
        }

        public Task<IEnumerable<SOLDOZA_MST_GRL_PROYECTOS>> GetProject(int id)
        {
            var projects = _context.proyectos.Include(p=>p.clientes)
                                             .Include(p=>p.versiones)
                                             .Include(p=>p.planos)
                                             .Include(p=>p.contactos).ThenInclude(cs=>cs.contacto)
                                             .Include(p=>p.contactos).ThenInclude(cs=>cs.tipocontacto)
                                             .Where(p=>p.id == id);
            return Task.FromResult(projects.AsEnumerable<SOLDOZA_MST_GRL_PROYECTOS>());
        }

        public bool Insert(SOLDOZA_MST_GRL_PROYECTOS project)
        {
            try
            {
                using (var cn = new NpgsqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    cn.Open();
                    sql = @"call sp_proyectos_insert(:p_cod_proyecto, :p_descripcion_proyecto, :p_cliente_id, :p_usuario_creacion)";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("p_cod_proyecto", DbType.String).Value = project.cod_proyecto.ToUpper();
                    cmd.Parameters.AddWithValue("p_descripcion_proyecto", DbType.String).Value = project.descripcion_proyecto.ToUpper();
                    cmd.Parameters.AddWithValue("p_cliente_id", DbType.Int32).Value = project.cliente_id;
                    cmd.Parameters.AddWithValue("p_usuario_creacion", DbType.String).Value = project.usuario_creacion;
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

        public bool Update(SOLDOZA_MST_GRL_PROYECTOS project)
        {
            try
            {
                if (project == null)
                {
                    return false;
                }

                _context.Update(project);
                _context.SaveChanges(true);
                return true;
            }
            catch
            {
                return false;
            }
           
        }

        public Task<IEnumerable<SOLDOZA_MST_GRL_PROYECTOS>> GetAll()
        {
            var projects = _context.proyectos.Include(p => p.clientes).Include(p => p.instalaciones).Include(p => p.versiones).Include(p=>p.planos);
            return Task.FromResult(projects.AsEnumerable<SOLDOZA_MST_GRL_PROYECTOS>());
        }

        public bool InsertVersion(SOLDOZA_MST_GRL_PROYECTOVERSION version)
        {
            try
            {
                using (var cn = new NpgsqlConnection(_context.Database.GetDbConnection().ConnectionString))
                {
                    cn.Open();
                    sql = @"call sp_proyectoversion_insert(:p_proyecto_id, :p_cod_version)";
                    NpgsqlCommand cmd = new NpgsqlCommand(sql, cn);
                    cmd.Parameters.AddWithValue("p_proyecto_id", DbType.Int32).Value = version.proyecto_id;
                    cmd.Parameters.AddWithValue("p_cod_version", DbType.String).Value = version.cod_version.ToUpper();
                    //cmd.Parameters.AddWithValue("p_fechainicio", DbType.Date).Value = version.fechainicio;
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

        public bool UpdateVersion(SOLDOZA_MST_GRL_PROYECTOVERSION version)
        {
            throw new NotImplementedException();
        }



    }
}
