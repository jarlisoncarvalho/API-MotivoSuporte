using Microsoft.AspNetCore.Mvc;
using MotivoSuporte.Entities;
using MotivoSuporte.Repository.Interfaces;

namespace MotivoSuporte.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class MotivosController : Controller
    {
        private readonly IMotivosRepository _motivosRepository;

        public MotivosController(IMotivosRepository motivosRepository)
        {
            _motivosRepository = motivosRepository;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Motivos>>> GetAllMotivos()

        {
            var motivos = await _motivosRepository.GetAll();
            return Ok(motivos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Motivos>> GetMotivoById(int id)
        {
            var motivos = await _motivosRepository.GetById(id);

            if (motivos == null) { 
                return NotFound("Motivo não encontrado");
            }
            return Ok(motivos);
        }

        [HttpPost]
        public async Task<ActionResult<Motivos>> AddMotivo([FromBody] Motivos motivo)
        {
            if (motivo == null || string.IsNullOrEmpty(motivo.Motivo)){
                return BadRequest("Os dados do motivo são inválidos");
            }
            await  _motivosRepository.Add(motivo);
            return CreatedAtAction(nameof(GetMotivoById), new { id = motivo.Id }, motivo);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Motivos>> EditMotivo(int id, [FromBody] Motivos EditMotivo)
        {
            if(EditMotivo == null || string.IsNullOrEmpty(EditMotivo.Motivo))
            {
                return BadRequest("Dados de Motivos são inválidos");
            }
            var motivo = await _motivosRepository.Update(id, EditMotivo);
            if (motivo == null)
            {
                return NotFound("Motivo não encontrado");

            }
            return Ok(motivo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotivo(int id)
        {
            var motivos = await _motivosRepository.GetById(id);
            if (motivos == null)
            {
                return NotFound("Motivo não encontrado");
            }
            await _motivosRepository.Delete(id);
            return Ok("Motivo excluído  com sucesso");
        }
    }
}
