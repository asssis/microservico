using api_publicidade.Migrations;
using api_publicidade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_publicidade.Jobs
{
    public class Seed
    {
        public void popular_banco()
        {
           var context = new ConectionSQLite();
            List<Usuario> usuario = context.Usuario.ToList();
            if (usuario.Count > 0)
                return;
            Usuario use = new Usuario()
            { Nome = "xxx", Email = "xxx@xx.com", Senha = "xxxx" };
            context.Usuario.Add(use);
            context.SaveChanges();

            Empresa emp = new Empresa()
            { Localizacao = "-8.733245,-63.857656", Nome = "Farmacon" };
            emp.Anuncios = new List<Anuncio>(){
                new Anuncio() { Descricao = "Prom Dipirona", Texto = "Promoção de dipirona 3R$, analgesico 5R$, corra, estoque limitado!", Empresa = emp },
                new Anuncio() { Descricao = "Saldão AAS", Texto = "Promoção de AAS infantil, corra, estoque limitado!", Empresa = emp },
                
            };
            context.Empresa.Add(emp);
            context.SaveChanges();

            emp = new Empresa()
            { Localizacao = "-8.733245,-63.857656", Nome = "Santo Remedio" };
            
            emp.Anuncios = new List<Anuncio>(){
                new Anuncio() { Descricao = "Bactrin Oferta", Texto = "Promoção de dipirona 3R$, analgesico 5R$, corra, estoque limitado!", Empresa = emp },
                new Anuncio() { Descricao = "Redoxom", Texto = "Promoção de AAS infantil, corra, estoque limitado!", Empresa = emp }        
            };
            context.Empresa.Add(emp);
            context.SaveChanges();

            emp = new Empresa()
            { Localizacao = "-8.733245,-63.857656", Nome = "Farma Boa" };

            emp.Anuncios = new List<Anuncio>(){
                new Anuncio() { Descricao = "Analgesico", Texto = "Promoção de dipirona 3R$, analgesico 5R$, corra, estoque limitado!", Empresa = emp },
                new Anuncio() { Descricao = "ASS 1 leve 4", Texto = "Promoção de AAS infantil, corra, estoque limitado!", Empresa = emp }        
            };
            context.Empresa.Add(emp);
            context.SaveChanges();
        }
    }
}
