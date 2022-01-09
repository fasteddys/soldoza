using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface ISOLDOZA_ADM_MST_CONSU_FABRICANTE
    {
        bool Insert(SOLDOZA_ADM_MST_CONSU_FABRICANTE cofab);
        bool Update(SOLDOZA_ADM_MST_CONSU_FABRICANTE cofab);
        IEnumerable<SOLDOZA_ADM_MST_CONSU_FABRICANTE> GetAll();
    }
}
