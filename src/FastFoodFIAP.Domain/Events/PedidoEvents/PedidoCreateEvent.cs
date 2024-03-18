using GenericPack.Messaging;


namespace FastFoodFIAP.Domain.Events.PedidoEvents
{
    public class PedidoCreateEvent:Event
    {
        public Guid Id { get; protected set; }
        public Guid PedidoId { get; set; }
        public Guid? FuncionarioId { get; protected set; }

        public Guid? ClientId { get; protected set; }
        public int SituacaoId { get; protected set; }

        public PedidoCreateEvent(Guid pedidoId, Guid? clientId, Guid? funcionarioId, int situacaoId)
        {
            Id = Guid.NewGuid();
            PedidoId = pedidoId;
            FuncionarioId = funcionarioId;
            ClientId = clientId;
            SituacaoId = situacaoId;
        }
    }
}
