using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("soldoza_adm_mst_consu_clasf_aws", Schema = "public")]
    public class SOLDOZA_ADM_MST_CONSU_CLASF_AWS
    {
        [Key]
        public int id { get; set; }
        public string cod_clasf_aws { get; set; }
        public string descripcion_clasf_aws { get; set; }

        public virtual ICollection<SOLDOZA_MST_CONSUMIBLES> consu { get; set; } = new HashSet<SOLDOZA_MST_CONSUMIBLES>();
    }
}
