using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GAT.Models
{
    public class Categorias
    {
        // criar o construtor
        public Categorias()
        {
            ListaTickets = new HashSet<Tickets>();
        }

        [Key] // chave primária
        public int ID { get; set; } // pk

        public string Categoria { get; set; }

        // Criar uma lista de tickets
        // por tipos de Assistencia
        public virtual ICollection<Tickets> ListaTickets { get; set; }

    }
}