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
    public class R_SOLDOZA_MST_PLANOS : ISOLDOZA_MST_PLANOS
    {
        private readonly ApplicationDbContext _context;

        public R_SOLDOZA_MST_PLANOS(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<SOLDOZA_MST_PLANOS>> GetAll(int id)
        {
            var plans = _context.planos.Where(p => p.proyecto_id == id).Include(p => p.proyecto);
            return Task.FromResult(plans.AsEnumerable<SOLDOZA_MST_PLANOS>());
        }
        public Task<IEnumerable<SOLDOZA_MST_PLANOS>> GetAll()
        {
            var plans = _context.planos.Include(p => p.proyecto);
            return Task.FromResult(plans.AsEnumerable<SOLDOZA_MST_PLANOS>());
        }

        public bool Insert(SOLDOZA_MST_PLANOS plano)
        {
            try
            {
                if (plano == null)
                {
                    return false;
                }

                _context.Add(plano);
                _context.SaveChanges(true);
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Update(SOLDOZA_MST_PLANOS plano)
        {
            try
            {
                if (plano == null)
                {
                    return false;
                }

                _context.Update(plano);
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
