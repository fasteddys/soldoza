using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Data.Repositories
{
    public class R_SOLDOZA_MST_PROC_SOLDADURA : ISOLDOZA_MST_PROC_SOLDADURA
    {
        private readonly ApplicationDbContext _context;

        public R_SOLDOZA_MST_PROC_SOLDADURA(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SOLDOZA_MST_PROC_SOLDADURA> GetAll()
        {
            return _context.prosol;
        }

        public bool Insert(SOLDOZA_MST_PROC_SOLDADURA prosol)
        {
            try
            {
                if (prosol == null)
                {
                    return false;
                }

                _context.Add(prosol);
                _context.SaveChanges(true);
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Update(SOLDOZA_MST_PROC_SOLDADURA prosol)
        {
            try
            {
                if (prosol == null)
                {
                    return false;
                }

                _context.Update(prosol);
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
