using web_anuncios.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_anuncios.Migrations
{
    public class ConectionSQLite : DbContext
    {
        public ConectionSQLite()
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Anuncio> Anuncio { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuild)
        {
            optionsBuild.UseSqlite("Filename=../db_dados.sqlite"); 

        }
    }
}
