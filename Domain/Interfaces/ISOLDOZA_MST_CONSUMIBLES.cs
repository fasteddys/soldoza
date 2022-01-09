using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISOLDOZA_MST_CONSUMIBLES
    {
        bool Insert(SOLDOZA_MST_CONSUMIBLES consu);
        bool Update(SOLDOZA_MST_CONSUMIBLES consu);
        //Task<IEnumerable<SOLDOZA_MST_CONSUMIBLES>> GetAll(int marcaid, int fabricanteid, int proc_soldaduraid, int clasf_awsid);
        Task<IEnumerable<SOLDOZA_MST_CONSUMIBLES>> GetAll();
    }
}
