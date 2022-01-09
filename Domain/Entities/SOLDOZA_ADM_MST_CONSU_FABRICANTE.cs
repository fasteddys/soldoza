using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("soldoza_adm_mst_consu_fabricante", Schema = "public")]
    public class SOLDOZA_ADM_MST_CONSU_FABRICANTE
    {
        [Key]
        public int id { get; set; }
        public string cod_fabricante { get; set; }
        public string descripcion_fabricante { get; set; }

        public virtual ICollection<SOLDOZA_MST_CONSUMIBLES> consu { get; set; } = new HashSet<SOLDOZA_MST_CONSUMIBLES>();
    }
}
