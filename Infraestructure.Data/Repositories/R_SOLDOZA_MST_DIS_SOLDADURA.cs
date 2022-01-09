using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Data.Repositories
{
    public class R_SOLDOZA_MST_DIS_SOLDADURA : ISOLDOZA_MST_DIS_SOLDADURA
    {
        private readonly ApplicationDbContext _context;

        public R_SOLDOZA_MST_DIS_SOLDADURA(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SOLDOZA_MST_DIS_SOLDADURA> GetAll()
        {
            return _context.disol;
        }

        public bool Insert(SOLDOZA_MST_DIS_SOLDADURA disol)
        {
            try
            {
                if (disol == null)
                {
                    return false;
                }

                _context.Add(disol);
                _context.SaveChanges(true);
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Update(SOLDOZA_MST_DIS_SOLDADURA disol)
        {
            try
            {
                if (disol == null)
                {
                    return false;
                }

                _context.Update(disol);
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
