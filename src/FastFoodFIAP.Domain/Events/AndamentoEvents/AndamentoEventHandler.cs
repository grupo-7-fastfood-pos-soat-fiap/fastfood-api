using Amazon.SQS;
using Amazon.SQS.Model;
using FastFoodFIAP.Domain.Models;

namespace FastFoodFIAP.Domain.Events.AndamentoEvents
{
    public class AndamentoEventHandler
    {
        AmazonSQSClient amazonSQSClient = new AmazonSQSClient();


        public async Task Handle(AndamentoCreateEvent notification)
        {
            Andamento andamento = new Andamento(notification.PedidoId, notification.FuncionarioId, notification.SituacaoId);

            if (andamento.SituacaoId == 2)
            {
                var request = new SendMessageRequest();
                request.QueueUrl = "https://sqs.us-east-1.amazonaws.com/381491906285/PedidoPreparacao.fifo";
                request.MessageBody = andamento.PedidoId.ToString();
                request.MessageGroupId = Guid.NewGuid().ToString();
                request.MessageDeduplicationId = Guid.NewGuid().ToString();

                // em preparacao
                await amazonSQSClient.SendMessageAsync(request);
            }
            
            if (andamento.SituacaoId == 3)
            {
                var request = new SendMessageRequest();
                request.QueueUrl = "https://sqs.us-east-1.amazonaws.com/381491906285/PedidoPronto.fifo";
                request.MessageBody = andamento.PedidoId.ToString();
                request.MessageGroupId = Guid.NewGuid().ToString();
                request.MessageDeduplicationId = Guid.NewGuid().ToString();

                // pronto
                await amazonSQSClient.SendMessageAsync(request);
            }
            
            if (andamento.SituacaoId == 4)
            {
                var request = new SendMessageRequest();
                request.QueueUrl = "https://sqs.us-east-1.amazonaws.com/381491906285/PedidoFinalizado.fifo";
                request.MessageBody = andamento.PedidoId.ToString();
                request.MessageGroupId = Guid.NewGuid().ToString();
                request.MessageDeduplicationId = Guid.NewGuid().ToString();
                
                // postar na fila de finalizado.
                await amazonSQSClient.SendMessageAsync(request);
            }

            return;            
        }       
    }
}
