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
    public class R_SOLDOZA_MST_SUBZONAS : ISOLDOZA_MST_SUBZONAS
    {
        private readonly ApplicationDbContext _context;

        public R_SOLDOZA_MST_SUBZONAS(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<SOLDOZA_MST_SUBZONAS>> GetAll(int id)
        {
            var subzone = _context.suzona.Where(s => s.zona_id == id).Include(s => s.zona);
            return Task.FromResult(subzone.AsEnumerable<SOLDOZA_MST_SUBZONAS>());
        }

        public Task<IEnumerable<SOLDOZA_MST_SUBZONAS>> GetAll()
        {
            var subzone = _context.suzona.Include(p => p.zona);
            return Task.FromResult(subzone.AsEnumerable<SOLDOZA_MST_SUBZONAS>());
        }

        public bool Insert(SOLDOZA_MST_SUBZONAS suzona)
        {
            try
            {
                if (suzona == null)
                {
                    return false;
                }

                _context.Add(suzona);
                _context.SaveChanges(true);
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Update(SOLDOZA_MST_SUBZONAS suzona)
        {
            try
            {
                if (suzona == null)
                {
                    return false;
                }

                _context.Update(suzona);
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
