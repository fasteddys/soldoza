using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("soldoza_mst_grl_clientes", Schema = "public")]
    public class SOLDOZA_MST_GRL_CLIENTES
    {
        [Key]
        public int id { get; set; }
        public string cod_cliente { get; set; }
        public int tipo_documento_id { get; set; }
        public string nrodoc_cliente { get; set; }
        public string nombre_cliente { get; set; }
        public string direccion_cliente { get; set; }
        public string pais { get; set; }
        public string ciudad { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string usuario_creacion { get; set; }
        public string usuario_actualizacion { get; set; }
        public DateTime? fecha_creacion { get; set; }
        public DateTime? fecha_actualizacion { get; set; }
        public char estado { get; set; }

        [ForeignKey("tipo_documento_id")]
        public SOLDOZA_MST_TIPO_DOCUMENTO tipodocumento { get; set; }
        public virtual ICollection<SOLDOZA_MST_GRL_PROYECTOS> proyectos { get; set; } = new HashSet<SOLDOZA_MST_GRL_PROYECTOS>();
        public virtual ICollection<SOLDOZA_MST_GRL_CONTACTOS> contactos { get; set; } = new HashSet<SOLDOZA_MST_GRL_CONTACTOS>();

    }
}
