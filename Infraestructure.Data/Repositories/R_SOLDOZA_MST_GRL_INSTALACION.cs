using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data.Repositories
{
    public class R_SOLDOZA_MST_GRL_INSTALACION : ISOLDOZA_MST_GRL_INSTALACION
    {
        private readonly ApplicationDbContext _context;

        public R_SOLDOZA_MST_GRL_INSTALACION(ApplicationDbContext context)
        {
            _context = context;
        }
        //public Task<IEnumerable<SOLDOZA_MST_CONSUMIBLES>> GetAll(int marcaid, int fabricanteid, int proc_soldaduraid, int clasf_awsid)
        //{
        //    var consum = _context.consu.Where(s => s.marca_id == marcaid).Include(s => s.marca).Where(s => s.fabricante_id == fabricanteid).Include(s => s.fabricante)
        //        .Where(s => s.proc_soldadura_id == proc_soldaduraid).Include(s => s.proc_soldadura).Where(s => s.clasf_aws_id == clasf_awsid).Include(s => s.clasf_aws);
        //    return Task.FromResult(consum.AsEnumerable<SOLDOZA_MST_CONSUMIBLES>());
        //}

        public Task<IEnumerable<SOLDOZA_MST_GRL_INSTALACION>> GetAll()
        {
            var instal = _context.insta.Include(s => s.proyectos).Include(s => s.insta_tipo);
            return Task.FromResult(instal.AsEnumerable<SOLDOZA_MST_GRL_INSTALACION>());
        }

        public bool Insert(SOLDOZA_MST_GRL_INSTALACION insta)
        {
            try
            {
                if (insta == null)
                {
                    return false;
                }

                _context.Add(insta);
                _context.SaveChanges(true);
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Update(SOLDOZA_MST_GRL_INSTALACION insta)
        {
            try
            {
                if (insta == null)
                {
                    return false;
                }

                _context.Update(insta);
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
