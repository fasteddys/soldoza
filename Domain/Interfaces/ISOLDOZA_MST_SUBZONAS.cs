using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISOLDOZA_MST_SUBZONAS
    {
        bool Insert(SOLDOZA_MST_SUBZONAS suzona);
        bool Update(SOLDOZA_MST_SUBZONAS suzona);
        Task<IEnumerable<SOLDOZA_MST_SUBZONAS>> GetAll(int id);
        Task<IEnumerable<SOLDOZA_MST_SUBZONAS>> GetAll();
    }
}
