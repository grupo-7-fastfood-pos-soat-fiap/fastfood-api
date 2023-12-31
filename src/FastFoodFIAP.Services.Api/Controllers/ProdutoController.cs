using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.Interfaces;
using FastFoodFIAP.Application.Services;
using FastFoodFIAP.Application.ViewModels;
using FastFoodFIAP.Domain.Models.ProdutoAggregate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Swashbuckle.AspNetCore.Annotations;

namespace FastFoodFIAP.Services.Api.Controllers
{
    [ApiController]
    [Route("api/produto")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class ProdutoController : ApiController
    {
        private readonly IProdutoApp _produtoApp;

        public ProdutoController(IProdutoApp produtoApp)
        {
            _produtoApp = produtoApp;
        }

        [HttpGet]
        [SwaggerOperation(
        Summary = "Lista todos os produtos.",
        Description = "Lista ordenada pelo nome de todos os produtos"
        )]
        [SwaggerResponse(200, "Success", typeof(List<ProdutoViewModel>))]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var lista = await _produtoApp.GetAll();
                return CustomListResponse(lista, lista.Count);
            }
            catch (Exception e)
            {
                return Problem("Há um problema com a sua requisição - " + e.Message);
            }
            
        }

        [HttpGet("categoria/{id}")]
        [SwaggerOperation(
        Summary = "Lista todos os produtos de uma categoria.",
        Description = "Lista ordenada pelo nome de todos os produtos de uma categoria"
        )]
        [SwaggerResponse(200, "Success", typeof(List<ProdutoViewModel>))]
        [SwaggerResponse(204, "No Content")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<ActionResult> GetAllByCategoria([FromRoute] Guid id)
        {
            try
            {
                var lista = await _produtoApp.GetAllByCategoria(id);
                return CustomListResponse(lista, lista.Count);
            }
            catch (Exception e)
            {
                return Problem("Há um problema com a sua requisição - " + e.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
        Summary = "Localiza um produto.",
        Description = "Localiza um produto pelo seu ID."
        )]
        [SwaggerResponse(200, "Success", typeof(ProdutoViewModel))]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                return CustomResponse(await _produtoApp.GetById(id));
            }
            catch (Exception e)
            {
                return Problem("Há um problema com a sua requisição - " + e.Message);
            }
            
        }

        [HttpPost]
        [SwaggerOperation(
        Summary = "Cria um novo produto.",
        Description = "Cria um novo produto."
        )]
        [SwaggerResponse(201, "Success", typeof(ProdutoViewModel))]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IActionResult> Post([FromBody] ProdutoInputModel produto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return CustomResponse(ModelState);

                var result = await _produtoApp.Add(produto);
                if (result.Id != null)
                    return CustomResponse(await _produtoApp.GetById((Guid)result.Id));
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
        Summary = "Atualiza um produto.",
        Description = "Atualiza um produto."
        )]
        [SwaggerResponse(204, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] ProdutoInputModel produto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return CustomResponse(ModelState);

                return CustomNoContentResponse(await _produtoApp.Update(id, produto));
            }
            catch (Exception e)
            {
                return Problem("Há um problema com a sua requisição - " + e.Message);
            }
            
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
        Summary = "Exclui um produto.",
        Description = "Exclui um produto."
        )]
        [SwaggerResponse(204, "Success")]
        [SwaggerResponse(400, "Bad Request")]
        [SwaggerResponse(404, "Not Found")]
        [SwaggerResponse(500, "Unexpected error")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                return CustomNoContentResponse(await _produtoApp.Remove(id));
            }
            catch (Exception e)
            {
                return Problem("Há um problema com a sua requisição - " + e.Message);
            }
            
        }
    }
}