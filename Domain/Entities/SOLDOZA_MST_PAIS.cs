using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("soldoza_mst_pais",Schema ="public")]
    public class SOLDOZA_MST_PAIS
    {
        [Key]
        public int id { get; set; }
        public string nombre_pais { get; set; }
    }
}
