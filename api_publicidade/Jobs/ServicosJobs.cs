using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace api_publicidade.Jobs
{
    public class ServicosJobs
    {
        public static readonly ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379");
      
    }
}
