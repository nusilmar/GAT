using System.ComponentModel.DataAnnotations;

namespace GAT.Models
{
    public class Prioridades
    // criar o construtor
    {

        [Key] // chave primária
        public int ID { get; set; } // pk

        public string Desc_Prioridade { get; set; }

    }
}