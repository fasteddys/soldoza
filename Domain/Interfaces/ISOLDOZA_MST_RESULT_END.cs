using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface ISOLDOZA_MST_RESULT_END
    {
        bool Insert(SOLDOZA_MST_RESULT_END rend);
        bool Update(SOLDOZA_MST_RESULT_END rend);
        IEnumerable<SOLDOZA_MST_RESULT_END> GetAll();
    }
}
