using System;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Newtonsoft.Json;
using web_anuncios.Migrations;
using web_anuncios.Models;

namespace web_anuncios.Jobs
{
    public class AnunciosJobs
    {
        
        public void ExecutarAnuncios()
        {  
            var th = new Thread(VerificarAnuncios);
            th.Start(); 
        }
        public void VerificarAnuncios(){ 
            var conf = new ConsumerConfig
            { 
                GroupId = "gravar_anuncios",
                BootstrapServers = "localhost:9092", 
                AutoOffsetReset = AutoOffsetReset.Earliest
            }; 

            var c = new ConsumerBuilder<Ignore, string>(conf).Build();
            c.Subscribe("anuncios"); 
            CancellationTokenSource cts = new CancellationTokenSource();    
            while (true)
            {
                try
                { 
                    var cr = c.Consume(cts.Token);
                    dynamic obj = JsonConvert.DeserializeObject(cr.Value);  
                    var context = new ConectionSQLite();
                    Anuncio anuncio =  context.Anuncio.Find((int)obj.Id);   
                    anuncio.Visualizado ++;
                    context.Anuncio.Update(anuncio);
                    context.SaveChanges(); 


                }
                catch (ConsumeException e)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"------------------- erro ------------------");
                    Console.WriteLine(e.Error.Reason);
                }
            }    
        }
    }
}
