using GenericPack.Domain;

namespace FastFoodFIAP.Domain.Models
{
    public class Andamento : Entity, IAggregateRoot
    {
        public Guid PedidoId { get; private set; }
        public Guid? FuncionarioId { get; private set; }
        public int SituacaoId { get; private set; }

        private Andamento()
        {

        }

        public Andamento(Guid pedidoId, Guid? funcionarioId, int situacaoId)
        {
            PedidoId = pedidoId;
            FuncionarioId = funcionarioId;
            SituacaoId = situacaoId;
        }
    }
}
