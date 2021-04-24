using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Model
{
    [Table("Usuario")]
    public class User
    {

        [Display(Name = "Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome")]
        [Display(Name = "Nome")]
        [Column("Nome")]
        public string Nome { get; set; }

        [Display(Name = "Email")]
        [Column("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha do cadastro")]
        [Display(Name = "Senha")]
        [Column("Senha")]
        public string Senha { get; set; }

        private string _role = "Comum";
        [Column("Role")]
        public string Role { get { return _role; }  set { _role = value; } }

    }
}
