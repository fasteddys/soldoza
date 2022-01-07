using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("soldoza_mst_result_end", Schema = "public")]
    public class SOLDOZA_MST_RESULT_END
    {
        [Key]
        public int id { get; set; }
        public string cod_result_end { get; set; }
        public string descripcion_result_end { get; set; }
    }
}
