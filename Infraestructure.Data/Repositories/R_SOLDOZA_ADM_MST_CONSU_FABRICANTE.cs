using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Data.Repositories
{
    public class R_SOLDOZA_ADM_MST_CONSU_FABRICANTE : ISOLDOZA_ADM_MST_CONSU_FABRICANTE
    {
        private readonly ApplicationDbContext _context;

        public R_SOLDOZA_ADM_MST_CONSU_FABRICANTE(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SOLDOZA_ADM_MST_CONSU_FABRICANTE> GetAll()
        {
            return _context.cofab;
        }

        public bool Insert(SOLDOZA_ADM_MST_CONSU_FABRICANTE cofab)
        {
            try
            {
                if (cofab == null)
                {
                    return false;
                }

                _context.Add(cofab);
                _context.SaveChanges(true);
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Update(SOLDOZA_ADM_MST_CONSU_FABRICANTE cofab)
        {
            try
            {
                if (cofab == null)
                {
                    return false;
                }

                _context.Update(cofab);
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
