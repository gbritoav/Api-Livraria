using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Model
{
    [Table("Autor")]
    public class Autor
    {
        [Key]
        [Display(Name = "Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Column("Nome")]
        public string Nome {get; set;}

        [Display(Name = "Descricao")]
        [Column("Descricao")]
        public string Descricao { get; set; }

        [Display(Name = "Nacionalidade")]
        [Column("Nacionalidade")]
        public string Nacionalidade { get; set; }

        [Display(Name = "DataNascimento")]
        [Column("DataNascimento")]
        public DateTime DataNascimento { get; set; }

      

    }
}
