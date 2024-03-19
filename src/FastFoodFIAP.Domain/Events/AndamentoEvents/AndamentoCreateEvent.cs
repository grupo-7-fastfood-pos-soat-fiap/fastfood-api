using GenericPack.Messaging;


namespace FastFoodFIAP.Domain.Events.AndamentoEvents
{
    public class AndamentoCreateEvent:Event
    {
        public Guid Id { get; protected set; }
        public Guid PedidoId { get; set; }
        public Guid? FuncionarioId { get; protected set; }
        public int SituacaoId { get; protected set; }

        public AndamentoCreateEvent(Guid pedidoId, Guid? funcionarioId, int situacaoId)
        {
            Id = Guid.NewGuid();
            PedidoId = pedidoId;
            FuncionarioId = funcionarioId;
            SituacaoId = situacaoId;
        }
    }
}
