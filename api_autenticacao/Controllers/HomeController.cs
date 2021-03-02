using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_publicidade.Jobs;
using api_publicidade.Migrations;
using api_publicidade.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_publicidade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<string> Index()
        {   
            ConectionSQLite context = new ConectionSQLite();
            List<Usuario>usuario = context.Usuario.ToList(); 
            Console.WriteLine(usuario[0].Email);
            Console.WriteLine(usuario[0].Senha);
            return "Serviço de anuncios";
        }
    }
}
