using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("soldoza_mst_detalle_pos_planorevision", Schema = "public")]
    public class SOLDOZA_MST_DETALLE_POS_PLANOREVISION
    {
        [Key]
        public int id { get; set; }
        public int plano_revision_id { get; set; }        
        public int list_pos_id { get; set; }
        public int material_id { get; set; }
        public int cantidad { get; set; }
        public string denominacion { get; set; }
        [Column(TypeName = "numeric")]
        public decimal longitud_1 { get; set; }
        [Column(TypeName = "numeric")]
        public decimal ancho_1 { get; set; }
        [Column(TypeName = "numeric")]
        public decimal longitud_2 { get; set; }
        [Column(TypeName = "numeric")]
        public decimal ancho_2 { get; set; }
        [Column(TypeName = "numeric")]
        public decimal espesor { get; set; }
        [Column(TypeName = "numeric")]
        public decimal peso { get; set; }
        public string observaciones { get; set; }

        [ForeignKey("plano_revision_id")]
        public SOLDOZA_MST_PLANO_REVISION plano_revision { get; set; }

        [ForeignKey("list_pos_id")]
        public SOLDOZA_ADM_PRY_ING_LIST_POS list_pos { get; set; }

        [ForeignKey("material_id")]
        public SOLDOZA_MST_MATERIALES material { get; set; }

    }
}
