using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("soldoza_mst_grl_proyectos", Schema = "public")]
    public class SOLDOZA_MST_GRL_PROYECTOS
    {
        [Key]
        public int id { get; set; }
        public string cod_proyecto { get;set; }
        public string descripcion_proyecto { get;set; }
        public int cliente_id { get; set; }
        public string usuario_creacion { get;set; }
        public string usuario_actualizacion { get;set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime? fecha_actualizacion { get; set; }
        public char estado { get; set; }
        
        [ForeignKey("cliente_id")]
        public SOLDOZA_MST_GRL_CLIENTES clientes { get; set; }
        public virtual ICollection<SOLDOZA_MST_GRL_PROYECTOVERSION> versiones { get; set; } = new HashSet<SOLDOZA_MST_GRL_PROYECTOVERSION>();
        public virtual ICollection<SOLDOZA_MST_CONTACTOS_PROYECTO> contactos { get; set; } = new HashSet<SOLDOZA_MST_CONTACTOS_PROYECTO>();
        public virtual ICollection<SOLDOZA_MST_PLANOS> planos { get; set; } = new HashSet<SOLDOZA_MST_PLANOS>();

    }
}
