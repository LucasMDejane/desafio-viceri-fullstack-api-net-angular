using Microsoft.AspNetCore.Mvc;
using EstudantesApi.Models;
using EstudantesApi.Services;
using System.Threading.Tasks;


namespace EstudantesApi.Controllers
{
    [ApiController] // controlador de API
    [Route("api/[controller]")] // rota base tipo: /api/Estudantes
    
    public class EstudantesController : ControllerBase
    {
        // injeção:

        private readonly EstudantesService _estudantesService; 

        public EstudantesController(EstudantesService estudantesService)
        {
            _estudantesService = estudantesService;
        }

        // POST para cadastrar estudante e notas
        // recebe os dados do corpo da requisição em formato JSON, mapeando:

        [HttpPost]
        public async Task<IActionResult> CadastrarEstudante([FromBody] EstudanteCadastroViewModel model)
        {
            var result = await _estudantesService.CadastrarEstudanteComNotas(model);

            if (result.Success)
            {
                // retornou sucesso = 201 Created ou 200
                return CreatedAtAction(nameof(CadastrarEstudante), new { message = result.Message });
            }
            else
            {
                // retornou falha = 400 Bad Request
                return BadRequest(new { message = result.Message });
            }
        }
    }
}
