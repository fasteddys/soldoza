using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Data.Repositories
{
    public class R_SOLDOZA_MST_POS_SOLDEO : ISOLDOZA_MST_POS_SOLDEO
    {
        private readonly ApplicationDbContext _context;

        public R_SOLDOZA_MST_POS_SOLDEO(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SOLDOZA_MST_POS_SOLDEO> GetAll()
        {
            return _context.posol;
        }

        public bool Insert(SOLDOZA_MST_POS_SOLDEO posol)
        {
            try
            {
                if (posol == null)
                {
                    return false;
                }

                _context.Add(posol);
                _context.SaveChanges(true);
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Update(SOLDOZA_MST_POS_SOLDEO posol)
        {
            try
            {
                if (posol == null)
                {
                    return false;
                }

                _context.Update(posol);
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
