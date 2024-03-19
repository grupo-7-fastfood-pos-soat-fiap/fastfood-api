using FastFoodFIAP.Domain.Events.AndamentoEvents;
using FastFoodFIAP.Domain.Models;
using FastFoodFIAP.Services.Api.Controllers;
using FastFoodProducao.Application.InputModels;
using FastFoodProducao.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FastFoodProducao.Services.Api.Controllers
{
    [ApiController]
    [Route("api/andamento")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class AndamentoController: ApiController
    {

        [HttpPost]
        [SwaggerOperation(
        Summary = "Criar um novo andamento para o pedido.",
        Description = "Criar um novo andamento para o pedido."
        )]
        [SwaggerResponse(201, "Success", typeof(List<AndamentoViewModel>))]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<ActionResult> CriarAndamento([FromBody] AndamentoInputModel andamento)
        {
            try {

                if (!ModelState.IsValid)
                    return CustomResponse(ModelState);
                
                AndamentoEventHandler andamentoEventHandler = new AndamentoEventHandler();
                await andamentoEventHandler.Handle(new AndamentoCreateEvent(andamento.pedidoId, andamento.FuncionarioId, andamento.SituacaoId));
                return CustomResponse();
            }
            catch (Exception e)
            {
                return Problem("Há um problema com a sua requisição - " + e.Message);
            }
            
        }
    }
}
