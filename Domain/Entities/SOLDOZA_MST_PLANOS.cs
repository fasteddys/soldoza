using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("soldoza_mst_planos", Schema = "public")]
    public class SOLDOZA_MST_PLANOS
    {
        [Key]
        public int id { get; set; }
        public int instalacion_id { get; set; }
        public string cod_num_plano { get; set; }
        public string descripcion_plano { get; set; }

        [ForeignKey("instalacion_id")]
        public SOLDOZA_MST_GRL_INSTALACION instalacion { get; set; }
        public virtual ICollection<SOLDOZA_MST_PLANO_REVISION> plano_revision { get; set; } = new HashSet<SOLDOZA_MST_PLANO_REVISION>();
        public virtual ICollection<SOLDOZA_ADM_PRY_ING_LIST_POS> pos { get; set; } = new HashSet<SOLDOZA_ADM_PRY_ING_LIST_POS>();
    }
}
