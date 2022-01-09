using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Data.Repositories
{
    public class R_SOLDOZA_MST_TIPO_JUNTA : ISOLDOZA_MST_TIPO_JUNTA
    {
        private readonly ApplicationDbContext _context;

        public R_SOLDOZA_MST_TIPO_JUNTA(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SOLDOZA_MST_TIPO_JUNTA> GetAll()
        {
            return _context.tijun;
        }

        public bool Insert(SOLDOZA_MST_TIPO_JUNTA tijun)
        {
            try
            {
                if (tijun == null)
                {
                    return false;
                }

                _context.Add(tijun);
                _context.SaveChanges(true);
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Update(SOLDOZA_MST_TIPO_JUNTA tijun)
        {
            try
            {
                if (tijun == null)
                {
                    return false;
                }

                _context.Update(tijun);
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
