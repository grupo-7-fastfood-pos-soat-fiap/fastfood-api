
using Amazon.SQS;

namespace FastFoodFIAP.Infra.Data.Mensageria
{
    public class PedidoMensageria
    {
        public static async Task SendMessage(string queueURL, string pedido)
        {
            var sqsClient = new AmazonSQSClient();

            await sqsClient.SendMessageAsync(queueURL, pedido);

        }
    }
}
