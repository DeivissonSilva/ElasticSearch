//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeBehind.ElasticSearch.Models;
using CodeBehind.ElasticSearch.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CodeBehind.ElasticSearch.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IEnumerable<Seglogs> Clientes { get; set; }
        private readonly ISeglogsRepository _rep;


        public IndexModel(ILogger<IndexModel> logger, ISeglogsRepository rep)
        {
            _logger = logger;
            _rep = rep;
        }

        public IActionResult OnGet()
        {
            _logger.LogInformation("Buscando dados");
            Clientes = _rep.Listar();

            return Page();
        }

    }
}
