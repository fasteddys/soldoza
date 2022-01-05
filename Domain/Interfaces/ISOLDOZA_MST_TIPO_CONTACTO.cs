using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISOLDOZA_MST_TIPO_CONTACTO
    {
        Task<IEnumerable<SOLDOZA_MST_TIPO_CONTACTO>> GetAll();
    }
}
