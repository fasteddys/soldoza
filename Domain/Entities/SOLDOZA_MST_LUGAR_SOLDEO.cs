using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("soldoza_mst_lugar_soldeo", Schema = "public")]
    public class SOLDOZA_MST_LUGAR_SOLDEO
    {
        [Key]
        public int id { get; set; }
        public string cod_lugar_soldeo { get; set; }
        public string descripcion_lugar_soldeo { get; set; }
    }
}
