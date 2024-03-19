using Amazon.SQS;
using Amazon.SQS.Model;
using FastFoodFIAP.Domain.Models.PedidoAggregate;
using MediatR;

namespace FastFoodFIAP.Domain.Events.PedidoEvents
{
    public class PedidoEventHandler: INotificationHandler<PedidoCreateEvent>
    {
        AmazonSQSClient amazonSQSClient = new AmazonSQSClient();

        public async Task Handle(PedidoCreateEvent notification, CancellationToken cancellationToken)
        {
            Pedido pedido = new Pedido(notification.PedidoId, notification.ClientId);
            var requestQueuePedidoRealizado = new SendMessageRequest();
            requestQueuePedidoRealizado.QueueUrl = "https://sqs.us-east-1.amazonaws.com/381491906285/PedidoRealizado.fifo";
            requestQueuePedidoRealizado.MessageBody = pedido.Id.ToString();
            requestQueuePedidoRealizado.MessageGroupId = Guid.NewGuid().ToString();
            requestQueuePedidoRealizado.MessageDeduplicationId = Guid.NewGuid().ToString();

            var requestQueuePedidoCobranca = new SendMessageRequest();
            requestQueuePedidoCobranca.QueueUrl = "https://sqs.us-east-1.amazonaws.com/381491906285/PedidoCobranca.fifo";
            requestQueuePedidoCobranca.MessageBody = pedido.Id.ToString();
            requestQueuePedidoCobranca.MessageGroupId = Guid.NewGuid().ToString();
            requestQueuePedidoCobranca.MessageDeduplicationId = Guid.NewGuid().ToString();

            await amazonSQSClient.SendMessageAsync(requestQueuePedidoRealizado);
            await amazonSQSClient.SendMessageAsync(requestQueuePedidoCobranca);

            return;            
        }       
    }
}
