using System.Threading;
using System.Threading.Tasks;
using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Interfaces.Services;
using FastFoodFIAP.Domain.Models;
using GenericPack.Data;
using GenericPack.Messaging;
using MediatR;


namespace FastFoodFIAP.Domain.Events.AndamentoEvents
{
    public class AndamentoEventHandler :
        INotificationHandler<AndamentoCreateEvent>
    {
        private readonly IProxyProducao _proxy;

        public AndamentoEventHandler(IProxyProducao proxy)
        {
            _proxy = proxy;
        }

        public async Task Handle(AndamentoCreateEvent notification, CancellationToken cancellationToken)
        {
            Andamento andamento = new Andamento(Guid.NewGuid(), notification.PedidoId, notification.FuncionarioId, notification.SituacaoId,notification.DataHoraInicio,notification.DataHoraFim,notification.Atual);
            var result = await _proxy.Add(andamento);

            return;            
        }       
    }
}
