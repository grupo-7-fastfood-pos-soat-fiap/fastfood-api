
using FastFoodFIAP.Domain.Interfaces.Services;
using FastFoodFIAP.Domain.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Net.Http.Json;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Xml.Linq;
using System.Text.Json.Serialization;
using FastFoodFIAP.Domain.Models.PedidoAggregate;

namespace FastFoodFIAP.Infra.Producao
{
    public class ProducaoService : IProxyProducao, IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly string user_id = "657762990";
        private readonly string external_pos_id = "SUC001POS001";
        private readonly string accessToken = "TEST-7091834242473976-082007-3f2848b83eb8c872aebc130399396854-657762990";

        public ProducaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Andamento?> Add(Andamento andamento)
        {
            
            var requisicaoJson = new StringContent(
               JsonSerializer.Serialize(andamento),
               Encoding.UTF8,
               Application.Json);

            _httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using var httpResponseMessage =
                await _httpClient.PostAsync($"api/andamento", requisicaoJson);

            var resultString = await httpResponseMessage.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(resultString))
                return null;

            return JsonSerializer.Deserialize<Andamento>(resultString);
        }

        public async Task<Andamento?> AndamentoAtualPedido(Guid pedidoId)
        {   
            _httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using var httpResponseMessage =
                await _httpClient.GetAsync($"api/andamento/{pedidoId}");

            var resultString = await httpResponseMessage.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(resultString))
                return null;

            return JsonSerializer.Deserialize<Andamento>(resultString);
        }

        public async Task<List<Andamento>?> AndamentosAtivos()
        {
            _httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using var httpResponseMessage =
                await _httpClient.GetAsync($"api/andamento/ativos");

            var resultString = await httpResponseMessage.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(resultString))
                return null;

            return JsonSerializer.Deserialize<List<Andamento>>(resultString);
        }

        public async Task<List<Andamento>?> AndamentosPorSituacao(int situacaoPedido)
        {
            try
            {

            
                _httpClient.DefaultRequestHeaders.Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using var httpResponseMessage =
                    await _httpClient.GetAsync($"api/andamento/situacao/{situacaoPedido}");

                var resultString = await httpResponseMessage.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(resultString))
                    return null;

                return JsonSerializer.Deserialize<List<Andamento>>(resultString);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<List<Andamento>?> Andamentos()
        {
            _httpClient.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            using var httpResponseMessage =
                await _httpClient.GetAsync($"api/andamento");

            var resultString = await httpResponseMessage.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(resultString))
                return null;

            return JsonSerializer.Deserialize<List<Andamento>>(resultString);
        }

        public void Dispose() => _httpClient?.Dispose();
    }
}
