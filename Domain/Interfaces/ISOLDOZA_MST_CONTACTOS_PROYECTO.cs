using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISOLDOZA_MST_CONTACTOS_PROYECTO
    {
        bool Insert(SOLDOZA_MST_CONTACTOS_PROYECTO contact);
        bool Delete(SOLDOZA_MST_CONTACTOS_PROYECTO contact);
        Task<IEnumerable<SOLDOZA_MST_CONTACTOS_PROYECTO>> GetAll(int id);

    }
}
