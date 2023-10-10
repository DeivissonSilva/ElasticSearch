using CodeBehind.ElasticSearch.Models;
using CodeBehind.ElasticSearch.Repository;
using CodeBehind.ElasticSearch.ViewModel;
using ElasticLogAPI.Mapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GestaoSegLogs.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SegLogsController : ControllerBase
    {
        private readonly ISeglogsRepository _segLogsRepository;

        public SegLogsController(ISeglogsRepository segLogsRepository)
        {
            _segLogsRepository = segLogsRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("adiciona")]
        public async Task<IActionResult> Create(SeglogVM seglogsVM)
        {
            if (!ModelState.IsValid) return BadRequest();

            Seglogs seglog = Mapper.SeglogVMParaSeglogs(seglogsVM);
            var retorno = _segLogsRepository.Persistir(seglog);

            if (retorno)
                return Ok(seglog);
            else
            {
                return BadRequest();
            }
        }
    }
}
