using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Data.Repositories
{
    public class R_SOLDOZA_MST_ZONAS : ISOLDOZA_MST_ZONAS
    {
        private readonly ApplicationDbContext _context;

        public R_SOLDOZA_MST_ZONAS(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SOLDOZA_MST_ZONAS> GetAll()
        {
                return _context.zonas;
        }

        public bool Insert(SOLDOZA_MST_ZONAS zone)
        {
            try
            {
                if (zone == null)
                {
                    return false;
                }

                _context.Add(zone);
                _context.SaveChanges(true);
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Update(SOLDOZA_MST_ZONAS zone)
        {
            try
            {
                if (zone == null)
                {
                    return false;
                }

                _context.Update(zone);
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
