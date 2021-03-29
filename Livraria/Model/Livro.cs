using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Model
{
    [Table("Livro")]
    public class Livro
    {
        [Key]
        [Display(Name = "Id")]
        [Column("Id")]
        public int Id { get; set; }


        [Required(ErrorMessage = "Informe o nome do livro")]
        [Display(Name = "Nome")]
        [Column("Nome")]
        public string Nome { get; set; }

        [Display(Name = "Descricao")]
        [Column("Descricao")]
        public string Descricao { get; set; }


        [ForeignKey("IdAutor")]
        [Display(Name = "Nome do Autor")]
        [Column("IdAutor")]
        public int IdAutor { get; set; }

        [ForeignKey("IdEditora")]
        [Display(Name = "Nome da Editora")]
        [Column("IdEditora")]
        public int IdEditora { get; set; }

        [ForeignKey("IdCategoria")]
        [Display(Name = "Nome da Categoria")]
        [Column("IdCategoria")]
        public int IdCategoria { get; set; }


        [Required(ErrorMessage = "Informe preço do livro")]
        [Display(Name = "Preço")]
        [Column("Preco")]
        public Decimal Preco { get; set; }
    }
}
