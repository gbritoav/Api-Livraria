using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Model
{
    public abstract class Context : DbContext
    {

        public DbSet<Autor> Autor { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Editora> Editora { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public string _connectionString { get; set; }
        public DbSet<User> Users { get; set; }


        public abstract void ConnectionString(string connectionString);
        public class ContextSqlServer : Context
        {

            public ContextSqlServer()
            {
                ConnectionString("ConexaoBDSQL");
            }
            public override void ConnectionString(string connectionString)
            {
                var configurationBuilder = new ConfigurationBuilder();
                string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                configurationBuilder.AddJsonFile(path, false);



                _connectionString = configurationBuilder.Build().GetSection("ConnectionStrings:" + connectionString).Value;
            }


            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }



        }




    }
}
