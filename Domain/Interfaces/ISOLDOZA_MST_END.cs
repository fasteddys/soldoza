using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface ISOLDOZA_MST_END
    {
        bool Insert(SOLDOZA_MST_END enode);
        bool Update(SOLDOZA_MST_END enode);
        IEnumerable<SOLDOZA_MST_END> GetAll();
    }
}
