using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Model
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        [Display(Name = "Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage ="Informe a descrição da categoria")]
        [Display(Name = "Descricao")]
        [Column("Descricao")]
        public string Descricao { get; set; }

    }
}
