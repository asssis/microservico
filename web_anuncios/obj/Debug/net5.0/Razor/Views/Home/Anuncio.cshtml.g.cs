#pragma checksum "/home/assis/microservices/api_publicidade/web_anuncios/Views/Home/Anuncio.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a13b95899b719207e3b93f00aed0d4f21865838a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Anuncio), @"mvc.1.0.view", @"/Views/Home/Anuncio.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "/home/assis/microservices/api_publicidade/web_anuncios/Views/_ViewImports.cshtml"
using web_anuncios;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/assis/microservices/api_publicidade/web_anuncios/Views/_ViewImports.cshtml"
using web_anuncios.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a13b95899b719207e3b93f00aed0d4f21865838a", @"/Views/Home/Anuncio.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8f6bd9885174d90e7dd7a486b8001bd45cae41db", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Anuncio : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(" \r\n");
#nullable restore
#line 2 "/home/assis/microservices/api_publicidade/web_anuncios/Views/Home/Anuncio.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Anuncios</h1> 
</div>
 
<canvas id=""myChart"" width=""400"" height=""200""></canvas>
<script>
var ctx = document.getElementById('myChart').getContext('2d'); 
var myChart = new Chart(ctx, {
    type: 'bar',
    label: 'Anuncios Visualizados',
    data: {
        labels: ");
#nullable restore
#line 17 "/home/assis/microservices/api_publicidade/web_anuncios/Views/Home/Anuncio.cshtml"
           Write(Html.Raw(@ViewBag.campos));

#line default
#line hidden
#nullable disable
            WriteLiteral(",\r\n        datasets: [{ \r\n            data: ");
#nullable restore
#line 19 "/home/assis/microservices/api_publicidade/web_anuncios/Views/Home/Anuncio.cshtml"
             Write(Html.Raw(@ViewBag.valores));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n        }]\r\n    },\r\n    options: {\r\n        scales: {\r\n            yAxes: [{\r\n                ticks: {\r\n                    beginAtZero: true\r\n                }\r\n            }]\r\n        }\r\n    }\r\n});\r\n</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
