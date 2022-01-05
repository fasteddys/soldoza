using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("soldoza_mst_tipo_documento", Schema = "public")]
    public class SOLDOZA_MST_TIPO_DOCUMENTO
    {
        [Key]
        public int id { get; set; }
        public string descripcion_tipo_documento { get; set; }
        public string abrev_tipo_documento { get; set; }
        public virtual ICollection<SOLDOZA_MST_GRL_CLIENTES> clientes { get; set; } = new HashSet<SOLDOZA_MST_GRL_CLIENTES>();

    }
}
