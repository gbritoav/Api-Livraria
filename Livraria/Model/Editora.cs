using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Model
{
    [Table("Editora")]
    public class Editora
    {
        [Key]
        [Display(Name = "Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome da editora")]
        [Display(Name = "Nome")]
        [Column("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o nome da fundacao")]
        [Display(Name = "Fundado")]
        [Column("Fundado")]
        public int Fundado { get; set; }

        [Required(ErrorMessage = "Informe a sede da editora")]
        [Display(Name = "Sede")]
        [Column("Sede")]
        public string Sede { get; set; }
    }
}
