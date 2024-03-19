using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.Interfaces;
using FastFoodFIAP.Application.Services;
using FastFoodFIAP.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FastFoodFIAP.Services.Api.Controllers
{
    [ApiController]
    [Route("api/lgpd")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class LgpdController : ApiController
    {
        private readonly ILgpdApp _lgpdApp;

        public LgpdController(ILgpdApp lgpdApp)
        {
            _lgpdApp = lgpdApp;
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Lista todos as solicitações LGPD.",
        Description = "Lista ordenada pelo nome de todas as solicitações LGPD"
        )]
        [SwaggerResponse(200, "Success", typeof(List<LgpdClienteViewModel>))]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var lista = await _lgpdApp.GetAll();
                return CustomListResponse(lista, lista.Count);
            }
            catch (Exception e)
            {
                return Problem("Há um problema com a sua requisição - " + e.Message);
            }

        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Solicitação de remoção de dados sensíveis pelo cliente (LGPD).",
        Description = "Solicitação de remoção de dados sensíveis pelo cliente (LGPD)."
        )]
        [SwaggerResponse(201, "Success", typeof(LgpdClienteViewModel))]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IActionResult> Post([FromBody] LgpdClienteInputModel lgpd)
        {
            try
            {
                if (!ModelState.IsValid)
                    return CustomResponse(ModelState);

                var result = await _lgpdApp.AddLgpdCliente(lgpd);
                if (result.Id != null)
                    return CustomResponse(await _lgpdApp.GetById((Guid)result.Id));
                else
                    return CustomCreateResponse(result);
            }
            catch (Exception e)
            {
                return Problem("Há um problema com a sua requisição - " + e.Message);
            }

        }        
    }
}
