using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Data.Repositories
{
    public class R_SOLDOZA_MST_RESULT_END : ISOLDOZA_MST_RESULT_END
    {
        private readonly ApplicationDbContext _context;

        public R_SOLDOZA_MST_RESULT_END(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SOLDOZA_MST_RESULT_END> GetAll()
        {
            return _context.rend;
        }

        public bool Insert(SOLDOZA_MST_RESULT_END rend)
        {
            try
            {
                if (rend == null)
                {
                    return false;
                }

                _context.Add(rend);
                _context.SaveChanges(true);
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Update(SOLDOZA_MST_RESULT_END rend)
        {
            try
            {
                if (rend == null)
                {
                    return false;
                }

                _context.Update(rend);
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
