using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface ISOLDOZA_MST_PROC_SOLDADURA
    {
        bool Insert(SOLDOZA_MST_PROC_SOLDADURA prosol);
        bool Update(SOLDOZA_MST_PROC_SOLDADURA prosol);
        IEnumerable<SOLDOZA_MST_PROC_SOLDADURA> GetAll();
    }
}
