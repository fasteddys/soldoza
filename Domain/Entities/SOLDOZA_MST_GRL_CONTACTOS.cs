using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("soldoza_mst_grl_contactos", Schema="public")]
    public class SOLDOZA_MST_GRL_CONTACTOS
    {
        [Key]
        public int id { get; set; }
        public int cliente_id { get; set; }
        public string cod_contacto { get; set; }
        public string nombre_contacto { get; set; }
        public string apellidos_contacto { get; set; }
        public string email_contacto { get; set; }
        public string telefono_contacto { get; set; }
        public char estado { get; set; }

        [ForeignKey("cliente_id")]
        public SOLDOZA_MST_GRL_CLIENTES cliente { get; set; }
        public virtual ICollection<SOLDOZA_MST_CONTACTOS_PROYECTO> contactos { get; set; } = new HashSet<SOLDOZA_MST_CONTACTOS_PROYECTO>();
    }
}
