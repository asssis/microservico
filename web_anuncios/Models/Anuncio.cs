using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;
namespace web_anuncios.Models
{
    public class Anuncio
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Texto { get; set; }
        public string ImagemBase64 { get; set; }
        public Empresa Empresa { get; set; }
        public int EmpresaId { get; set; }
        public int Visualizado{get; set;}
 
    }
}
