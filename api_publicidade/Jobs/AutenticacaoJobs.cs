using api_publicidade.Migrations;
using api_publicidade.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_publicidade.Jobs
{
    public class AutenticacaoJobs
    {
        public Boolean VerificarAutenticacao(string token)
        {
            if(String.IsNullOrEmpty(token))
                return false;
            string chave =     Convert.ToString(token); 
            string json = ServicosJobs.redis.GetDatabase().StringGet(chave); 
            if (String.IsNullOrEmpty(json))
                return false; 
            return true;
        }
        public string CriarAutenticacao(string email, string senha)
        {
            Usuario usuario; 
            ConectionSQLite context = new ConectionSQLite();
            usuario = context.Usuario.Where(x => x.Email == email).FirstOrDefault<Usuario>();
            if (usuario == null || usuario.Senha != senha)
                return null;
            string token = Guid.NewGuid().ToString();
            string dados = JsonConvert.SerializeObject(usuario);
            ServicosJobs.redis.GetDatabase().StringSet(token, dados);
            return token;
        }
    }
}
