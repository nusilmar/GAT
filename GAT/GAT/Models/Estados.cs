using System.ComponentModel.DataAnnotations;

namespace GAT.Models
{
    public class Estados
    {
        // criar o construtor

        [Key] // chave primária
        public int ID { get; set; } // pk

        public string Desc_Status { get; set; }

    }
}