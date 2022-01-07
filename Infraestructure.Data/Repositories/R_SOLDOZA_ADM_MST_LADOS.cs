using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Data.Repositories
{
    public class R_SOLDOZA_ADM_MST_LADOS : ISOLDOZA_ADM_MST_LADOS
    {
        private readonly ApplicationDbContext _context;

        public R_SOLDOZA_ADM_MST_LADOS(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SOLDOZA_ADM_MST_LADOS> GetAll()
        {
            return _context.lados;
        }
        public bool Insert(SOLDOZA_ADM_MST_LADOS side)
        {
            try
            {
                if (side == null)
                {
                    return false;
                }

                _context.Add(side);
                _context.SaveChanges(true);
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Update(SOLDOZA_ADM_MST_LADOS side)
        {
            try
            {
                if (side == null)
                {
                    return false;
                }

                _context.Update(side);
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
