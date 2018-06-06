using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GAT.Models
{
    public class Clientes
    {
        // criar o construtor
        public Clientes()
        {
            ListaTickets = new HashSet<Tickets>();
        }

        [Key] // chave primária
        public int ID { get; set; } // pk

        public string Nome { get; set; }

        public string Morada { get; set; }

        public string CodPostal { get; set; }
		
        public string Localidade { get; set; }

        public string Telemovel { get; set; }

        public DateTime DataAbertura { get; set; }

        [ForeignKey("SLA")]
        public int SLAFK { get; set; }
        public virtual SLAs SLA { get; set; }

        // Criar uma lista de tickets
        // pedidos pelo Cliente
        public virtual ICollection<Tickets> ListaTickets { get; set; }

        // FK Para tabela de autenticação
        public string UserName { get; set; }



    }
}