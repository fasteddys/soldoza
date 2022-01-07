using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface ISOLDOZA_MST_POS_SOLDEO
    {
        bool Insert(SOLDOZA_MST_POS_SOLDEO posol);
        bool Update(SOLDOZA_MST_POS_SOLDEO posol);
        IEnumerable<SOLDOZA_MST_POS_SOLDEO> GetAll();
    }
}
