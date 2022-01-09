using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface ISOLDOZA_MST_LUGAR_SOLDEO
    {
        bool Insert(SOLDOZA_MST_LUGAR_SOLDEO lusol);
        bool Update(SOLDOZA_MST_LUGAR_SOLDEO lusol);
        IEnumerable<SOLDOZA_MST_LUGAR_SOLDEO> GetAll();
    }
}
