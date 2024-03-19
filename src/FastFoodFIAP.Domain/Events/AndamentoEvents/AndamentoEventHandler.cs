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
                await PublicarMensagemNaFila(andamento, "https://sqs.us-east-1.amazonaws.com/381491906285/PedidoPreparacao.fifo");
            } else if (andamento.SituacaoId == 3)
            {
                await PublicarMensagemNaFila(andamento, "https://sqs.us-east-1.amazonaws.com/381491906285/PedidoPronto.fifo");
            } else if (andamento.SituacaoId == 4)
            {
                await PublicarMensagemNaFila(andamento, "https://sqs.us-east-1.amazonaws.com/381491906285/PedidoFinalizado.fifo");
            }

            return;            
        }

        public async Task PublicarMensagemNaFila(Andamento andamento, string queueURL)
        {
            var request = new SendMessageRequest();
            request.QueueUrl = queueURL;
            request.MessageBody = andamento.PedidoId.ToString();
            request.MessageGroupId = Guid.NewGuid().ToString();
            request.MessageDeduplicationId = Guid.NewGuid().ToString();

            // em preparacao
            await amazonSQSClient.SendMessageAsync(request);
        }
    }
}
