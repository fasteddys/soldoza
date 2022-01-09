using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Data.Repositories
{
    public class R_SOLDOZA_ADM_MST_CONSU_CLASF_AWS : ISOLDOZA_ADM_MST_CONSU_CLASF_AWS
    {
        private readonly ApplicationDbContext _context;

        public R_SOLDOZA_ADM_MST_CONSU_CLASF_AWS(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SOLDOZA_ADM_MST_CONSU_CLASF_AWS> GetAll()
        {
            return _context.coclasfaws;
        }

        public bool Insert(SOLDOZA_ADM_MST_CONSU_CLASF_AWS coclasfaws)
        {
            try
            {
                if (coclasfaws == null)
                {
                    return false;
                }

                _context.Add(coclasfaws);
                _context.SaveChanges(true);
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Update(SOLDOZA_ADM_MST_CONSU_CLASF_AWS coclasfaws)
        {
            try
            {
                if (coclasfaws == null)
                {
                    return false;
                }

                _context.Update(coclasfaws);
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
