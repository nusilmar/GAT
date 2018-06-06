using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GAT.Models
{
    public class Tecnicos
    {
        //criar o construtor
        public Tecnicos()
        {
            ListaTickets = new HashSet<Tickets>();
        }

        [Key] // chave primária
        public int ID { get; set; }

        //dados do Tecnico : Nome
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [DisplayName("Nome do Técnico")]
        [RegularExpression("[A-ZÂÁÓÉÍ][a-záéíóúàèìòùâêîôûãõçäëöüïñ]+(( | e | de | da | das | do | d'|-)[A-ZÂÁÓÉÍ][a-záéíóúàèìòùâêîôûãõçäëöüïñ]+){1,3}",
      ErrorMessage = "o {0} só aceita letras. Cada nome deve começar por uma maiúscula seguida de minúsculas...")]
        [StringLength(50, ErrorMessage = "o {0} só aceita {1} carateres.")]
        public string Nome { get; set; }

        //dados do Tecnico : E-Mail
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Só é permitido email")]
        [StringLength(90, ErrorMessage = "o {0} só aceita {1} carateres.")]
        public string TecEmail { get; set; }

        public string Fotografia { get; set; }

        // Area de Trabalho do Técnico
        [StringLength(80, ErrorMessage = "o {0} só aceita {1} carateres.")]
        public string Area { get; set; }

        // Criar uma lista de Tickets
        // aplicadas pelo Tecnico
        public virtual ICollection<Tickets> ListaTickets { get; set; }

        // FK Para tabela de autenticação
        public string UserName { get; set; }


    }
}