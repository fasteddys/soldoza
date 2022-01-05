using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISOLDOZA_MST_GRL_CLIENTES
    {
        void Insert(SOLDOZA_MST_GRL_CLIENTES customer);
        void Update(SOLDOZA_MST_GRL_CLIENTES customer);
        Task<IEnumerable<SOLDOZA_MST_GRL_CLIENTES>> GetAll();
        IEnumerable<SOLDOZA_MST_GRL_CLIENTES> GetAll2();
        Task<SOLDOZA_MST_GRL_CLIENTES> GetCustomer(int id);
    }
}
