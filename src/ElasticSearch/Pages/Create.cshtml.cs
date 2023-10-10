//***CODE BEHIND - BY RODOLFO.FONSECA***//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CodeBehind.ElasticSearch.Models;
using Microsoft.Extensions.Logging;
using CodeBehind.ElasticSearch.Repository;

namespace CodeBehind.ElasticSearch.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;

        [BindProperty]
        public Seglogs cliente { get; set; }

        private readonly ISeglogsRepository _rep;

        public string Mensagem { get; set; }

        public CreateModel(ILogger<CreateModel> logger, ISeglogsRepository rep)
        {
            _logger = logger;
            _rep = rep;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
      
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                cliente.log_acao = Guid.NewGuid().ToString();
                var retorno = _rep.Persistir(cliente);

                if (retorno)
                    Mensagem = "Sucesso";
                else Mensagem = "Erro";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Create");
                Mensagem = ex.Message;
            }
            return Page();
        }
    }
}
