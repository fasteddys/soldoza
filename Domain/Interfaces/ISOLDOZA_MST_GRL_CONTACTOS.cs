using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISOLDOZA_MST_GRL_CONTACTOS
    {
        bool Insert(SOLDOZA_MST_GRL_CONTACTOS contact);
        bool Update(SOLDOZA_MST_GRL_CONTACTOS contact);
        Task<IEnumerable<SOLDOZA_MST_GRL_CONTACTOS>> GetAll(int id);
        Task<IEnumerable<SOLDOZA_MST_GRL_CONTACTOS>> GetAll();

    }
}
