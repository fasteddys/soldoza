using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface ISOLDOZA_MST_ZONAS
    {
        bool Insert(SOLDOZA_MST_ZONAS zone);
        bool Update(SOLDOZA_MST_ZONAS zone);
        IEnumerable<SOLDOZA_MST_ZONAS> GetAll();
    }
}
