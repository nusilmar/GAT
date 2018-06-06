using System.ComponentModel.DataAnnotations;

namespace GAT.Models
{
    public class SLAs
    {

        [Key] // chave primária
        public int ID { get; set; } // pk

        public string SLA_Desc { get; set; }

        public int horas { get; set; }

    }
}