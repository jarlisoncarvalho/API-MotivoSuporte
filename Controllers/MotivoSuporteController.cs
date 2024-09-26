using Microsoft.AspNetCore.Mvc;
using MotivoSuporte.Entities;
using MotivoSuporte.Model;
using MotivoSuporte.Repository.Interfaces;
using System.Threading.Tasks;

namespace MotivoSuporte.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MotivoSuporteController : Controller
    {
        private readonly IMotivoSuporteRepository _motivoSuporteRepository;
        private readonly IEmpresaRepository _empresaRepository;

        public MotivoSuporteController(IMotivoSuporteRepository motivoSuporteRepository, IEmpresaRepository empresaRepository)
        {
            _motivoSuporteRepository = motivoSuporteRepository;
            _empresaRepository = empresaRepository;
        }

        [HttpPost("adicionarMotivo")]
        public async Task<IActionResult> AddMotivoSuporteEmpresa([FromBody] AddMotivo request)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            if (request == null)
            {
                return BadRequest("Dados de motivo e empresa são necessários.");
            }

            var motivoSuporte = new Motivo_Suporte
            {
                Idf_Empresa = request.Idf_Empresa,
                Motivo = request.Motivo,
                Des_Motivo = request.Des_Motivo,
                Num_CNPJ = request.Num_CNPJ,
                Raz_Social = request.Raz_Social,
                Email= request.Email,
                Telefone = request.Telefone,
                Situacao = request.Situacao,
                Qtde_Admissoes = request.Qtde_Admissoes,
                Qtde_Funcionarios = request.Qtde_Funcionarios,
                Origem = request.Origem,
            };

            await _motivoSuporteRepository.Add(motivoSuporte);

            return Ok("Motivo de suporte adicionado com sucesso à empresa.");
        }

        [HttpGet("motivos/cnpj/{cnpj}")]
        public async Task<IActionResult> GetEmpresaWithMotivoByCnpj(decimal cnpj)
        {
            var motivos = await _motivoSuporteRepository.GetByCnpj(cnpj);
            if (motivos == null || !motivos.Any())
            {
                return NotFound();
            }
            return Ok(motivos);
        }

        [HttpPut("EditarMotivo")]
        public async Task<IActionResult> EditEmpresaWithMotivo(int id, [FromBody] EditMotivoSuporte request)
        {
            if (request == null) {

                return BadRequest("é necessário informar o Motivo.");
            }
            try
            {
                var motivoSuporte = await _motivoSuporteRepository.GetById(id);

                if (motivoSuporte == null)
                {
                    return BadRequest("Motivo de Suporte não Encontrado");
                }
                motivoSuporte.Motivo = request.Motivo;
                motivoSuporte.Des_Motivo = request.Des_Motivo;

                await _motivoSuporteRepository.Edit(motivoSuporte);

                return Ok("Motivo de suporte atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresaWithMotivo(int id)
        {
            var motivoSuporte = await _motivoSuporteRepository.GetById(id);
            if(motivoSuporte == null)
            {
                return NotFound("Nenhuma empresa com motivo encontrada");
            }
            await _motivoSuporteRepository.Delete(id);
            return Ok("motivo de empresa deletado com sucesso");
        }
    }
}