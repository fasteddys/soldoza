using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("soldoza_mst_end", Schema = "public")]
    public class SOLDOZA_MST_END
    {
        [Key]
        public int id { get; set; }
        public string cod_end { get; set; }
        public string descripcion_end { get; set; }
    }
}
