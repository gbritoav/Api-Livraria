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

        [Display(Name = "Nome")]
        [Column("Nome")]
        public string Nome { get; set; }

        [Display(Name = "Fundado")]
        [Column("Fundado")]
        public int Fundado { get; set; }

        [Display(Name = "Sede")]
        [Column("Sede")]
        public string Sede { get; set; }
    }
}
