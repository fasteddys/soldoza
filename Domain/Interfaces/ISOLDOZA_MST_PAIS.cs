using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISOLDOZA_MST_PAIS
    {
        IEnumerable<SOLDOZA_MST_PAIS> GetAll();
    }
}
