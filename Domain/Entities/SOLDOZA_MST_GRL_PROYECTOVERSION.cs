using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("soldoza_mst_grl_proyectoversion", Schema = "public")]
    public class SOLDOZA_MST_GRL_PROYECTOVERSION
    {
        [Key]
        public int id { get; set; }
        public int proyecto_id { get; set; }
        public string cod_version { get; set; }
        public DateTime fechainicio { get; set; }
        public DateTime? fechafin { get; set; }

        [ForeignKey("proyecto_id")]
        public SOLDOZA_MST_GRL_PROYECTOS proyecto { get; set; } 

    }
}
