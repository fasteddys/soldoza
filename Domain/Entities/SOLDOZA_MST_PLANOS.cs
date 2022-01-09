using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("soldoza_mst_planos", Schema = "public")]
    public class SOLDOZA_MST_PLANOS
    {
        [Key]
        public int id { get; set; }
        public int proyecto_id { get; set; }
        public string cod_num_plano { get; set; }
        public string descripcion_plano { get; set; }

        [ForeignKey("proyecto_id")]
        public SOLDOZA_MST_GRL_PROYECTOS proyecto { get; set; }
    }
}
