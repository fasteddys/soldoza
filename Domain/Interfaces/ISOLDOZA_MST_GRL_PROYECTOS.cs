using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISOLDOZA_MST_GRL_PROYECTOS
    {
        bool Insert(SOLDOZA_MST_GRL_PROYECTOS project);
        bool Update(SOLDOZA_MST_GRL_PROYECTOS project);

        Task<IEnumerable<SOLDOZA_MST_GRL_PROYECTOS>> GetProjects(int id);
        Task<IEnumerable<SOLDOZA_MST_GRL_PROYECTOS>> GetAll();

        bool InsertVersion(SOLDOZA_MST_GRL_PROYECTOVERSION version);
        bool UpdateVersion(SOLDOZA_MST_GRL_PROYECTOVERSION version);

    }
}
