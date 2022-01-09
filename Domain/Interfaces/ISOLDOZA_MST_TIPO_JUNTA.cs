using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface ISOLDOZA_MST_TIPO_JUNTA
    {
        bool Insert(SOLDOZA_MST_TIPO_JUNTA tijun);
        bool Update(SOLDOZA_MST_TIPO_JUNTA tijun);
        IEnumerable<SOLDOZA_MST_TIPO_JUNTA> GetAll();
    }
}
