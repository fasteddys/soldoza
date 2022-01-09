using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Data.Repositories
{
    public class R_SOLDOZA_ADM_MST_CONSU_MARCA : ISOLDOZA_ADM_MST_CONSU_MARCA
    {
        private readonly ApplicationDbContext _context;

        public R_SOLDOZA_ADM_MST_CONSU_MARCA(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SOLDOZA_ADM_MST_CONSU_MARCA> GetAll()
        {
            return _context.comar;
        }

        public bool Insert(SOLDOZA_ADM_MST_CONSU_MARCA comar)
        {
            try
            {
                if (comar == null)
                {
                    return false;
                }

                _context.Add(comar);
                _context.SaveChanges(true);
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Update(SOLDOZA_ADM_MST_CONSU_MARCA comar)
        {
            try
            {
                if (comar == null)
                {
                    return false;
                }

                _context.Update(comar);
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
