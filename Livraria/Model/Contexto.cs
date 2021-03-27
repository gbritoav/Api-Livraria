using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Model
{
    public class Contexto : DbContext
    {

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
            Database.EnsureCreated();

        }

        public DbSet<Autor> Autor { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Editora> Editora { get; set; }
        public DbSet<Livro> Livro { get; set; }


    }
}
