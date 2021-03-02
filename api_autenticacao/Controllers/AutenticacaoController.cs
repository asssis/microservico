using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using api_publicidade.Jobs;
using api_publicidade.Migrations;
using api_publicidade.Models; 
using Contentful.Core.Models.Management;
using Microsoft.AspNetCore.Mvc; 
using Newtonsoft.Json; 

namespace api_publicidade.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<dynamic> Login()
        {   
            var request = HttpContext.Request;
            var stream = new StreamReader(request.Body);  
            var body = await stream.ReadToEndAsync();
            dynamic obj = JsonConvert.DeserializeObject(body); 
            string token = new AutenticacaoJobs().CriarAutenticacao((string)obj.email, (string)obj.senha);
            
            if (token == null)
                return Unauthorized(new { msn = "falha na autenticacao", status = 0 });
            else
                return Ok(new { token = token, msn = "login efetuado com sucesso", status = 1 });

        }
    }
}


 