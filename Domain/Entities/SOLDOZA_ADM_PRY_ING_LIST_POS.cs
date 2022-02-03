using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("soldoza_adm_pry_ing_list_pos", Schema = "public")]
    public class SOLDOZA_ADM_PRY_ING_LIST_POS
    {
        [Key]
        public int id { get; set; }
        public int plano_id { get; set; }
        public string cod_pos { get; set; }

        [ForeignKey("plano_id")]
        public SOLDOZA_MST_PLANOS plano { get; set; }

        public virtual ICollection<SOLDOZA_MST_DETALLE_POS_PLANOREVISION> detalle_pos_planorev { get; set; } = new HashSet<SOLDOZA_MST_DETALLE_POS_PLANOREVISION>();
    }
}
