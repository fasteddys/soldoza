using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("soldoza_mst_tipo_junta", Schema = "public")]
    public class SOLDOZA_MST_TIPO_JUNTA
    {
        [Key]
        public int id { get; set; }
        public string cod_tipo_junta { get; set; }
        public string descripcion_tipo_junta { get; set; }
    }
}
