﻿using System;
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
        public virtual ICollection<SOLDOZA_MST_DETALLE_POS_PLANOREVISION> detalle_pos_planorev { get; set; } = new HashSet<SOLDOZA_MST_DETALLE_POS_PLANOREVISION>();
    }
}
