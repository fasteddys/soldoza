using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Entities
{
    [Table("soldoza_mst_revisiones_fechas", Schema = "public")]
    public class SOLDOZA_PY_REVISIONES_FECHAS
    {
        [Key]
        public int id { get; set; }
        public int revision_id { get; set; }
        [Column(TypeName = "date")]
        public DateTime fecha { get; set; }
        [ForeignKey("revision_id")]
        public SOLDOZA_PY_REVISIONES revision { get; set; }

    }
}
