using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISOLDOZA_MST_GRL_INSTALACION
    {
        bool Insert(SOLDOZA_MST_GRL_INSTALACION insta);
        bool Update(SOLDOZA_MST_GRL_INSTALACION insta);
        //Task<IEnumerable<SOLDOZA_MST_CONSUMIBLES>> GetAll(int marcaid, int fabricanteid, int proc_soldaduraid, int clasf_awsid);
        //Task<IEnumerable<SOLDOZA_MST_GRL_INSTALACION>> GetAll(int id);
        Task<IEnumerable<SOLDOZA_MST_GRL_INSTALACION>> GetAll();
    }
}
