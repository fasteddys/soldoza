using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("soldoza_mst_contactos_proyecto", Schema = "public")]
    public class SOLDOZA_MST_CONTACTOS_PROYECTO
    {
        [Key, Column("contacto_id", Order = 0)]
        public int contacto_id { get; set; }

        [Key, Column("proyecto_id", Order = 1)]
        public int proyecto_id { get; set; }
        public int tipo_contacto_id { get; set; }
        [ForeignKey("contacto_id")]
        public SOLDOZA_MST_GRL_CONTACTOS contacto { get; set; }
        [ForeignKey("proyecto_id")]
        public SOLDOZA_MST_GRL_PROYECTOS proyecto { get; set; }
        [ForeignKey("tipo_contacto_id")]
        public SOLDOZA_MST_TIPO_CONTACTO tipocontacto { get; set; }
    }
}
