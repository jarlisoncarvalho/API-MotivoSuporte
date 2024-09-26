using Microsoft.AspNetCore.Mvc;
using MotivoSuporte.Entities;
using MotivoSuporte.Model;
using MotivoSuporte.Repository;
using MotivoSuporte.Repository.Interfaces;

namespace MotivoSuporte.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaController(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }
        [HttpGet("idf/{idfEmpresa}")]
        public async Task<IActionResult> GetByIdf(int idfEmpresa)
        {
            var empresa = await _empresaRepository.Get(idfEmpresa);
            if (empresa == null)
            {
                return NotFound("Empresa não econtrada pelo IDF");
            }
            return Ok(empresa);
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetAllEmpresas()
        {
            var empresas = await _empresaRepository.GetAll();
            if (!empresas.Any())
            {
                return NoContent();
            }
            return Ok(empresas);
        }
        [HttpGet("cnpj/{cnpj}")]
        public async Task<IActionResult> GetEmpresaByCnpj(decimal cnpj)
        {
            var empresa = await _empresaRepository.GetByCnpj(cnpj);
            if (empresa == null)
            {
                return NotFound("Empresa não encontrada");
            }
            return Ok(empresa);
        }

    }

}
