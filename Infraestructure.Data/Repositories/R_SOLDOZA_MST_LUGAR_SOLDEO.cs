using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Data.Repositories
{
    public class R_SOLDOZA_MST_LUGAR_SOLDEO : ISOLDOZA_MST_LUGAR_SOLDEO
    {
        private readonly ApplicationDbContext _context;

        public R_SOLDOZA_MST_LUGAR_SOLDEO(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SOLDOZA_MST_LUGAR_SOLDEO> GetAll()
        {
            return _context.lusol;
        }

        public bool Insert(SOLDOZA_MST_LUGAR_SOLDEO lusol)
        {
            try
            {
                if (lusol == null)
                {
                    return false;
                }

                _context.Add(lusol);
                _context.SaveChanges(true);
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Update(SOLDOZA_MST_LUGAR_SOLDEO lusol)
        {
            try
            {
                if (lusol == null)
                {
                    return false;
                }

                _context.Update(lusol);
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
