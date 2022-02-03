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
    public class R_SOLDOZA_ADM_PRY_ING_LIST_POS : ISOLDOZA_ADM_PRY_ING_LIST_POS
    {
        private readonly ApplicationDbContext _context;

        public R_SOLDOZA_ADM_PRY_ING_LIST_POS(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<SOLDOZA_ADM_PRY_ING_LIST_POS>> GetAll()
        {
            var list_pos = _context.pos.Include(s => s.plano);
            return Task.FromResult(list_pos.AsEnumerable<SOLDOZA_ADM_PRY_ING_LIST_POS>());
        }

        public bool Insert(SOLDOZA_ADM_PRY_ING_LIST_POS pos)
        {
            try
            {
                if (pos == null)
                {
                    return false;
                }

                _context.Add(pos);
                _context.SaveChanges(true);
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Update(SOLDOZA_ADM_PRY_ING_LIST_POS pos)
        {
            try
            {
                if (pos == null)
                {
                    return false;
                }

                _context.Update(pos);
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
