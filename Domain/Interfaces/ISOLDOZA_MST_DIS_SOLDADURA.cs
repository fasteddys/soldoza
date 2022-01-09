using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface ISOLDOZA_MST_DIS_SOLDADURA
    {
        bool Insert(SOLDOZA_MST_DIS_SOLDADURA disol);
        bool Update(SOLDOZA_MST_DIS_SOLDADURA disol);
        IEnumerable<SOLDOZA_MST_DIS_SOLDADURA> GetAll();
    }
}
