using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("soldoza_py_revisiones", Schema = "public")]
    public class SOLDOZA_PY_REVISIONES
    {
        [Key]
        public int id { get; set; }
        public string cod_revision { get; set; }
        public string descripcion_revision { get; set; }
        public int plano_id { get; set; }
        [ForeignKey("plano_id")]
        public SOLDOZA_MST_PLANOS plano { get; set; }
        public virtual ICollection<SOLDOZA_PY_REVISIONES_FECHAS> fechas { get; set; } = new HashSet<SOLDOZA_PY_REVISIONES_FECHAS>();
    }
}
