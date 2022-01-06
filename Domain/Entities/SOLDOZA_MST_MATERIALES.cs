using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("soldoza_mst_materiales", Schema = "public")]
    public class SOLDOZA_MST_MATERIALES
    {
        [Key]
        public int id { get; set; }
        public string cod_material { get; set; }
        public string descripcion_material { get; set; }
        public string p_num { get; set; }
        public string g_num { get; set; }

    }
}
