using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface ISOLDOZA_MST_GRL_INSTALACION_TIPO
    {
        bool Insert(SOLDOZA_MST_GRL_INSTALACION_TIPO insta_tipo);
        bool Update(SOLDOZA_MST_GRL_INSTALACION_TIPO insta_tipo);
        IEnumerable<SOLDOZA_MST_GRL_INSTALACION_TIPO> GetAll();
    }
}
