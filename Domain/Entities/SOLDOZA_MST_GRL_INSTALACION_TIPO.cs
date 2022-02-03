using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("soldoza_mst_grl_instalacion_tipo", Schema = "public")]
    public class SOLDOZA_MST_GRL_INSTALACION_TIPO
    {
        [Key]
        public int id { get; set; }
        public string cod_tipo_instalacion { get; set; }
        public string descripcion_tipo_instalacion { get; set; }
        public virtual ICollection<SOLDOZA_MST_GRL_INSTALACION> insta { get; set; } = new HashSet<SOLDOZA_MST_GRL_INSTALACION>();
    }
}
