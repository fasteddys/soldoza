using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Data.Repositories
{
    public class R_SOLDOZA_MST_GRL_INSTALACION_TIPO : ISOLDOZA_MST_GRL_INSTALACION_TIPO
    {
        private readonly ApplicationDbContext _context;

        public R_SOLDOZA_MST_GRL_INSTALACION_TIPO(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SOLDOZA_MST_GRL_INSTALACION_TIPO> GetAll()
        {
            return _context.instatipo;
        }
        public bool Insert(SOLDOZA_MST_GRL_INSTALACION_TIPO insta_tipo)
        {
            try
            {
                if (insta_tipo == null)
                {
                    return false;
                }

                _context.Add(insta_tipo);
                _context.SaveChanges(true);
                return true;

            }
            catch
            {
                return false;
            }
        }

        public bool Update(SOLDOZA_MST_GRL_INSTALACION_TIPO insta_tipo)
        {
            try
            {
                if (insta_tipo == null)
                {
                    return false;
                }

                _context.Update(insta_tipo);
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
