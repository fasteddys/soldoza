using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("soldoza_mst_zonas", Schema = "public")]
    public class SOLDOZA_MST_ZONAS
    {
        [Key]
        public int id { get; set; }
        public string cod_zona { get; set; }
        public string descripcion_zona { get; set; }

        public virtual ICollection<SOLDOZA_MST_SUBZONAS> subzona { get; set; } = new HashSet<SOLDOZA_MST_SUBZONAS>();
    }
}
