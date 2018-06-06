using System.ComponentModel.DataAnnotations;

namespace GAT.Models
{
    public class Tipos
    {
        [Key] // chave primária
        public int ID { get; set; } // pk

        public string Desc_Tipo { get; set; }

    }
}