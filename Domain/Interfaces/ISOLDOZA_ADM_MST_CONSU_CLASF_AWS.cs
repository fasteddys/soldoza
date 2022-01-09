using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface ISOLDOZA_ADM_MST_CONSU_CLASF_AWS
    {
        bool Insert(SOLDOZA_ADM_MST_CONSU_CLASF_AWS coclasfaws);
        bool Update(SOLDOZA_ADM_MST_CONSU_CLASF_AWS coclasfaws);
        IEnumerable<SOLDOZA_ADM_MST_CONSU_CLASF_AWS> GetAll();
    }
}
