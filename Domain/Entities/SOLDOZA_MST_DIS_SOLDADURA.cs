using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("soldoza_mst_dis_soldadura", Schema = "public")]
    public class SOLDOZA_MST_DIS_SOLDADURA
    {
        [Key]
        public int id { get; set; }
        public string cod_dis_soldadura { get; set; }
        public string descripcion_dis_soldadura { get; set; }
    }
}
