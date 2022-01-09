using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    [Table("soldoza_mst_consumibles", Schema = "public")]
    public class SOLDOZA_MST_CONSUMIBLES
    {
        [Key]
        public int id { get; set; }
        public int marca_id { get; set; }
        public int fabricante_id { get; set; }
        public int proc_soldadura_id { get; set; }
        public int clasf_aws_id { get; set; }
        public decimal diametro { get; set; }
        public decimal ref_rendto { get; set; }
        public string f_num { get; set; }
        public string a_num { get; set; }
        public decimal densidad { get; set; }
        public string long_electrodo { get; set; }
        public decimal precio { get; set; }
        public decimal num_elect_kg { get; set; }
        public string cod_consumible { get; set; }

        [ForeignKey("marca_id")]
        public SOLDOZA_ADM_MST_CONSU_MARCA marca { get; set; }

        [ForeignKey("fabricante_id")]
        public SOLDOZA_ADM_MST_CONSU_FABRICANTE fabricante { get; set; }

        [ForeignKey("proc_soldadura_id")]
        public SOLDOZA_MST_PROC_SOLDADURA proc_soldadura { get; set; }

        [ForeignKey("clasf_aws_id")]
        public SOLDOZA_ADM_MST_CONSU_CLASF_AWS clasf_aws { get; set; }
    }
}
