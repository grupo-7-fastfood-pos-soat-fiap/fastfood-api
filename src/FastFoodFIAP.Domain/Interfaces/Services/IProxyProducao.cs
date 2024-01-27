
using FastFoodFIAP.Domain.Models;

namespace FastFoodFIAP.Domain.Interfaces.Services
{
    public interface IProxyProducao
    {
        Task<Andamento> AndamentoAtual(Guid pedidoId);
        Task<List<Andamento>> AndamentosAtivos();
        Task<List<Andamento>> AndamentosPorSituacao(int situacaoPedido);
    }
}
