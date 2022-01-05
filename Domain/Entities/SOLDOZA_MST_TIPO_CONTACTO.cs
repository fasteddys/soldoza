using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("soldoza_mst_tipo_contacto", Schema ="public")]
    public class SOLDOZA_MST_TIPO_CONTACTO
    {
        [Key]
        public int id { get; set; }
        public string cod_tipo_contacto { get; set; }
        public string descripcion_tipo_contacto { get; set; }
        public virtual ICollection<SOLDOZA_MST_CONTACTOS_PROYECTO> contactos { get; set; } = new HashSet<SOLDOZA_MST_CONTACTOS_PROYECTO>();
    }
}
