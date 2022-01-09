using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("soldoza_adm_mst_consu_marca", Schema = "public")]
    public class SOLDOZA_ADM_MST_CONSU_MARCA
    {
        [Key]
        public int id { get; set; }
        public string cod_marca { get; set; }
        public string descripcion_marca { get; set; }

        public virtual ICollection<SOLDOZA_MST_CONSUMIBLES> consu { get; set; } = new HashSet<SOLDOZA_MST_CONSUMIBLES>();
    }
}
