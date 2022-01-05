using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISOLDOZA_MST_TIPO_DOCUMENTO
    {
        Task<IEnumerable<SOLDOZA_MST_TIPO_DOCUMENTO>> GetAll();
    }
}
