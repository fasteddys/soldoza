using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISOLDOZA_ADM_PRY_ING_LIST_POS
    {
        bool Insert(SOLDOZA_ADM_PRY_ING_LIST_POS pos);
        bool Update(SOLDOZA_ADM_PRY_ING_LIST_POS pos);
        //Task<IEnumerable<SOLDOZA_MST_CONSUMIBLES>> GetAll(int marcaid, int fabricanteid, int proc_soldaduraid, int clasf_awsid);
        Task<IEnumerable<SOLDOZA_ADM_PRY_ING_LIST_POS>> GetAll();
    }
}
