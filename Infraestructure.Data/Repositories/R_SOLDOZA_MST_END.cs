using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Data.Repositories
{
    public class R_SOLDOZA_MST_END : ISOLDOZA_MST_END
    {
        private readonly ApplicationDbContext _context;

        public R_SOLDOZA_MST_END(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SOLDOZA_MST_END> GetAll()
        {
            return _context.enode;
        }

        public bool Insert(SOLDOZA_MST_END enode)
        {
            try
            {
                if (enode == null)
                {
                    return false;
                }

                _context.Add(enode);
                _context.SaveChanges(true);
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Update(SOLDOZA_MST_END enode)
        {
            try
            {
                if (enode == null)
                {
                    return false;
                }

                _context.Update(enode);
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
