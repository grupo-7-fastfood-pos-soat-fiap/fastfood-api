
using FastFoodFIAP.Domain.Models;

namespace FastFoodFIAP.Domain.Interfaces.Services
{
    public interface IProxyProducao
    {
        Task<Andamento> Add(Andamento andamento);
        Task<Andamento> AndamentoAtualPedido(Guid pedidoId);
        Task<List<Andamento>> AndamentosAtivos();
        Task<List<Andamento>> AndamentosPorSituacao(int situacaoPedido);
        Task<List<Andamento>> Andamentos();
    }
}
