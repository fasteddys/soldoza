using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("soldoza_mst_grl_instalacion", Schema = "public")]
    public class SOLDOZA_MST_GRL_INSTALACION
    {
        [Key]
        public int id { get; set; }
        public int proyecto_id { get; set; }
        public int tipo_instalacion_id { get; set; }
        public string cod_instalacion { get; set; }
        public string descripcion_instalacion { get; set; }

        [ForeignKey("proyecto_id")]
        public SOLDOZA_MST_GRL_PROYECTOS proyectos { get; set; }

        [ForeignKey("tipo_instalacion_id")]
        public SOLDOZA_MST_GRL_INSTALACION_TIPO insta_tipo { get; set; }

        public virtual ICollection<SOLDOZA_MST_PLANOS> plano { get; set; } = new HashSet<SOLDOZA_MST_PLANOS>();
    }
}
