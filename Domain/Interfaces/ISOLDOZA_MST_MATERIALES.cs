using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISOLDOZA_MST_MATERIALES
    {
        bool Insert(SOLDOZA_MST_MATERIALES contact);
        bool Update(SOLDOZA_MST_MATERIALES contact);
        Task<IEnumerable<SOLDOZA_MST_MATERIALES>> GetAll();
    }
}
