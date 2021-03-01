using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_publicidade.Jobs;
using api_publicidade.Migrations;
using api_publicidade.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace api_publicidade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnuncioController : ControllerBase
    {
        [HttpPost("Consultar")]
        public async Task<dynamic> Consultar()
        { 
            string token = Request.Headers["token"]; 
            var request = HttpContext.Request;

            if(!new AutenticacaoJobs().VerificarAutenticacao(token))
                return Unauthorized(new { msn = "falha na autenticacao", status = 0 });

       

            var stream = new StreamReader(request.Body); 
            var body = await stream.ReadToEndAsync();  
            dynamic obj = null;
            try
            {
                obj = JsonConvert.DeserializeObject(body); 
            }
            catch{ 
                return BadRequest(new { status = 0, msn = "Falha no Parametro de localização, Verifique se o formato json está correto" });
            } 
            string localizacao = obj.localizacao;   
            Anuncio anuncio =  new AnunciosJobs().consultar(localizacao);
            if(anuncio == null) 
                return Ok(new { status = 2, msn = "Sem Anuncios", anuncio = "{}" }); 

            dynamic json = new { descricao = "", imagem = anuncio.ImagemBase64, texto = anuncio.Texto };
            return Ok(new { status = 1, msn = "Requisição Ok", anuncio = json });
        }


    }
}
