using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("soldoza_mst_subzonas", Schema = "public")]
    public class SOLDOZA_MST_SUBZONAS
    {
        [Key]
        public int id { get; set; }
        public int zona_id { get; set; }
        public string cod_subzona { get; set; }
        public string descripcion_subzona { get; set; }

        [ForeignKey("zona_id")]
        public SOLDOZA_MST_ZONAS zona { get; set; }
    }
}
