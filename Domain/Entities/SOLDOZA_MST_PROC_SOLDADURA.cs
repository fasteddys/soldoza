using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("soldoza_mst_proc_soldadura", Schema = "public")]
    public class SOLDOZA_MST_PROC_SOLDADURA
    {
        [Key]
        public int id { get; set; }
        public string cod_proc_soldadura { get; set; }
        public string descripcion_proc_soldadura { get; set; }

        public virtual ICollection<SOLDOZA_MST_CONSUMIBLES> consu { get; set; } = new HashSet<SOLDOZA_MST_CONSUMIBLES>();
    }
}
