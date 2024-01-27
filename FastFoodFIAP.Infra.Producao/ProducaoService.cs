
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
        public async Task<Andamento> AndamentoAtual(Guid pedidoId)
        {
            //var requisicaoJson = new StringContent(
            //   JsonSerializer.Serialize(requisicao),
            //   Encoding.UTF8,
            //   Application.Json);

            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            //using var httpResponseMessage =
            //    await _httpClient.PostAsync($"instore/orders/qr/seller/collectors/{user_id}/pos/{external_pos_id}/qrs", requisicaoJson);

            //var resultString = await httpResponseMessage.Content.ReadAsStringAsync();

            //return string.IsNullOrEmpty(resultString)
            //? new QrData()
            //: JsonSerializer.Deserialize<QrData>(resultString);

            throw new NotImplementedException();
        }

        public async Task<List<Andamento>> AndamentosAtivos()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Andamento>> AndamentosPorSituacao(int situacaoPedido)
        {
            throw new NotImplementedException();
        }

        public void Dispose() => _httpClient?.Dispose();
    }
}
