using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("soldoza_adm_mst_lados", Schema = "public")]
    public class SOLDOZA_ADM_MST_LADOS
    {
        [Key]
        public int id { get; set; }
        public string cod_lado { get; set; }
        public string descripcion_lado { get; set; }
    }
}
