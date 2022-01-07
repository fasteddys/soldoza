using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("soldoza_mst_pos_soldeo", Schema = "public")]
    public class SOLDOZA_MST_POS_SOLDEO
    {
        [Key]
        public int id { get; set; }
        public string cod_pos_soldeo { get; set; }
        public string descripcion_pos_soldeo { get; set; }
    }
}
