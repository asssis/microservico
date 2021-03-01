using api_publicidade.Migrations;
using api_publicidade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;
using Newtonsoft.Json;

namespace api_publicidade.Jobs
{
    public class AnunciosJobs
    {
        static string topic_anuncios = "anuncios";
        public Anuncio consultar(string localizacao) {
 
            ConectionSQLite context = new ConectionSQLite();
            List<Empresa> empresas = context.Empresa.ToList();
            List<Anuncio> anuncios = new List<Anuncio>(); 
            //pegando todos os anuncios
            foreach (Empresa empresa in empresas)
            { 
                double distancia = new CordenadasJobs().CalcularDistancia(empresa.Localizacao, localizacao);
                if (distancia < 15)
                {
                    anuncios.AddRange(context.Anuncio.Where(x => empresa.Id == x.EmpresaId).ToList());
                }
            } 
            if(anuncios.Count <= 0)
                return null;
            Anuncio anuncio = anuncio = anuncios[new Random().Next(anuncios.Count)];  
            ContarAnuncios(anuncio);  
            return anuncio;
        }
        public async Task ContarAnuncios(Anuncio anuncio) {
            var options = new KafkaOptions (new Uri("http://localhost:9092"));
            var router = new BrokerRouter(options); 
            var client = new KafkaNet.Producer(router);  
            anuncio.Empresa = null;
            string jsonString = JsonConvert.SerializeObject(anuncio); 
            client.SendMessageAsync("anuncios", new[] { new Message(jsonString) }).Wait();  
        }
    }
}
