using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GAT.Models
{
    public class Tickets
    {
        [Key] // chave primária
        public int ID { get; set; }

        // dados do Ticket
        
        public string Problema { get; set; }

        public string Descricao { get; set; }

        // Como se faz um campo do tipo time ??
        public int TempoDispendido { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataAberturaTicket { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataFechoTicket { get; set; }

        // *******************************************
        // especificação das chaves forasteiras
        // *******************************************

        // FK para o Agente
        // em SQL:
        // ... Foreignkey NomeDaVarQueÉFK references NomeDaTabela(nomeDaPK)
        [ForeignKey("Tecnico")]
        public int TecnicoFK { get; set; }
        public virtual Tecnicos Tecnico { get; set; }

        // FK para Cliente
        [ForeignKey("Cliente")]
        public int ClienteFK { get; set; }
        public virtual Clientes Cliente { get; set; }

        // FK para Categoria
        [ForeignKey("Categoria")]
        public int CategoriaFK { get; set; }
        public virtual Categorias Categoria { get; set; }

        // FK para Estado
        [ForeignKey("Status")]
        public int StatusFK { get; set; }
        public virtual Estados Status { get; set; }

        // FK para Tipo
        [ForeignKey("Tipo")]
        public int TipoFK { get; set; }
        public virtual Tipos Tipo { get; set; }

        // FK para Prioridade
        [ForeignKey("Prioridade")]
        public int PrioridadeFK { get; set; }
        public virtual Prioridades Prioridade { get; set; }

    }
}