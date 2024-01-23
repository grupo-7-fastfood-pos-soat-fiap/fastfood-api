using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.Interfaces;
using FastFoodFIAP.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

namespace FastFoodFIAP.Services.Api.Controllers
{
    [ApiController]
    [Route("api/pedido")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class PedidoController: ApiController
    {
        private readonly IPedidoApp _pedidoApp;

        public PedidoController(IPedidoApp pedidoApp)
        {
            _pedidoApp = pedidoApp;
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Lista todos os pedidos.",
        Description = "Lista ordenada pela data de todos os pedidos"
        )]
        [SwaggerResponse(200, "Success", typeof(List<PedidoViewModel>))]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var lista = await _pedidoApp.GetAll();
                return CustomListResponse(lista, lista.Count);
            }
            catch (Exception e)
            {
                return Problem("Há um problema com a sua requisição - " + e.Message);
            }
            
        }

        [HttpGet("ativos")]
        [SwaggerOperation(
        Summary = "Lista todos os pedidos ativos.",
        Description = "Lista agrupada por situação e ordenada pela data e hora de todos os pedidos ativos"
        )]
        [SwaggerResponse(200, "Success", typeof(List<PedidoViewModel>))]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<ActionResult> GetAllAtivos()
        {
            try
            {
                var lista = await _pedidoApp.GetAllAtivos();
                return CustomListResponse(lista, lista.Count);
            }
            catch (Exception e)
            {
                return Problem("Há um problema com a sua requisição - " + e.Message);
            }

        }


        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Localiza um pedido.",
        Description = "Localiza um pedido pelo seu ID."
        )]
        [SwaggerResponse(200, "Success", typeof(PedidoViewModel))]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                return CustomResponse(await _pedidoApp.GetById(id));
            }
            catch (Exception e)
            {
                return Problem("Há um problema com a sua requisição - " + e.Message);
            }
            
        }

        [Authorize]
        [HttpPost]
        [SwaggerOperation(
        Summary = "Cria um novo pedido.",
        Description = "Cria um novo pedido."
        )]
        [SwaggerResponse(201, "Success", typeof(PedidoViewModel))]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IActionResult> Post([FromBody] PedidoInputModel pedidoInputModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return CustomResponse(ModelState);

                var claimsIdentity = User.Identity as ClaimsIdentity;
                var cpf = claimsIdentity?.Claims.FirstOrDefault(x => x.Type == "Cpf");
                var clienteId = claimsIdentity?.Claims.FirstOrDefault(x => x.Type == "ClienteId");

                if (cpf == null || clienteId == null)
                    return StatusCode(StatusCodes.Status401Unauthorized);                

                pedidoInputModel.SetCliente(Guid.Parse(clienteId.Value));

                var result = await _pedidoApp.Add(pedidoInputModel);
                if (result.Id != null)
                    return CustomResponse(await _pedidoApp.GetById((Guid)result.Id));
                else
                    return CustomCreateResponse(result);
            }
            catch (Exception e)
            {
                return Problem("Há um problema com a sua requisição - " + e.Message);
            }            
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
        Summary = "Atualiza um pedido.",
        Description = "Atualiza um pedido."
        )]
        [SwaggerResponse(204, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] PedidoInputModel pedido)
        {
            try
            {
                if (!ModelState.IsValid)
                    return CustomResponse(ModelState);

                return CustomNoContentResponse(await _pedidoApp.Update(id, pedido));
            }
            catch (Exception e)
            {
                return Problem("Há um problema com a sua requisição - " + e.Message);
            }
            
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Exclui um pedido.",
        Description = "Exclui um pedido."
        )]
        [SwaggerResponse(204, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                return CustomNoContentResponse(await _pedidoApp.Remove(id));
            }
            catch (Exception e)
            {
                return Problem("Há um problema com a sua requisição - " + e.Message);
            }            
        }
        
        [HttpGet("situacao/{id}")]
        [SwaggerOperation(
        Summary = "Lista todos os pedidos por situacao.",
        Description = "Lista ordenada pela data de todos os pedidos por situacao"
        )]
        [SwaggerResponse(200, "Success", typeof(List<PedidoViewModel>))]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<ActionResult> GetAllBySituacao([FromRoute] int id)
        {
            try
            {
                var lista = await _pedidoApp.GetAllBySituacao(id);
                return CustomListResponse(lista, lista.Count);
            }
            catch (Exception e)
            {
                return Problem("Há um problema com a sua requisição - " + e.Message);
            }
            
        }
    }
}
