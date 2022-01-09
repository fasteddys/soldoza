using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface ISOLDOZA_ADM_MST_CONSU_MARCA
    {
        bool Insert(SOLDOZA_ADM_MST_CONSU_MARCA comar);
        bool Update(SOLDOZA_ADM_MST_CONSU_MARCA comar);
        IEnumerable<SOLDOZA_ADM_MST_CONSU_MARCA> GetAll();
    }
}
