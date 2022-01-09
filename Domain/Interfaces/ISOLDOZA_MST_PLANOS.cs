using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISOLDOZA_MST_PLANOS
    {
        bool Insert(SOLDOZA_MST_PLANOS plano);
        bool Update(SOLDOZA_MST_PLANOS plano);
        Task<IEnumerable<SOLDOZA_MST_PLANOS>> GetAll(int id);
        Task<IEnumerable<SOLDOZA_MST_PLANOS>> GetAll();
    }
}
