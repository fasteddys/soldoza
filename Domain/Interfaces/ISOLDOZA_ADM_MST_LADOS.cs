using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface ISOLDOZA_ADM_MST_LADOS
    {
        bool Insert(SOLDOZA_ADM_MST_LADOS side);
        bool Update(SOLDOZA_ADM_MST_LADOS side);
        IEnumerable<SOLDOZA_ADM_MST_LADOS> GetAll();
    }
}
