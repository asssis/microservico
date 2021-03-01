using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using web_anuncios.Migrations;
using web_anuncios.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; 

namespace web_anuncios.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Anuncio()
        {   
            ConectionSQLite context = new ConectionSQLite();
            List<Anuncio> anuncios = context.Anuncio.ToList();  
            List<int> valores = new List<int>();
            List<string> campos = new List<string>();
            foreach(Anuncio item in anuncios){ 
               valores.Add(item.Visualizado);
               campos.Add(item.Descricao);
            } 
            ViewBag.campos =  $"['{String.Join("','", campos)}']"; 
            ViewBag.valores = $"['{String.Join("','", valores)}']";  
            return View();
        }

        public IActionResult Empresa()
        {ConectionSQLite context = new ConectionSQLite();
            List<Empresa> empresas = context.Empresa.ToList();  
            List<int> valores = new List<int>();
            List<string> campos = new List<string>();
            foreach(Empresa item in empresas){
               List<Anuncio> anuncios = context.Anuncio.Where(x => x.EmpresaId == item.Id).ToList(); 
               int total = 0;
               foreach(Anuncio anuncio in anuncios){ 
                    total += anuncio.Visualizado;
               }
               valores.Add(total);
               campos.Add(item.Nome);
            }
          

            ViewBag.campos =  $"['{String.Join("','", campos)}']"; 
            ViewBag.valores = $"['{String.Join("','", valores)}']";  
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
