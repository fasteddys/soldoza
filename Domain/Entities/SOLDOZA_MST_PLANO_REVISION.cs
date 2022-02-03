using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("soldoza_mst_planos_revision", Schema = "public")]
    public class SOLDOZA_MST_PLANO_REVISION
    {
        [Key]
        public int id { get; set; }
        public int plano_id { get; set; }
        public int nro_revision { get; set; }
        public DateTime fecha_revision { get; set; }

        [ForeignKey("plano_id")]
        public SOLDOZA_MST_PLANOS plano { get; set; }

        public virtual ICollection<SOLDOZA_MST_DETALLE_POS_PLANOREVISION> detalle_pos_planorev { get; set; } = new HashSet<SOLDOZA_MST_DETALLE_POS_PLANOREVISION>();
    }
}
