namespace FastFoodProducao.Application.ViewModels
{
    public class AndamentoViewModel
    {
        public Guid Id { get; set; }
        public Guid PedidoId { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime? DataHoraFim { get; set; }
        public Guid FuncionarioId { get; set; }
        public int SituacaoId { get; set; }
        public bool Atual { get; set; }

        public AndamentoViewModel() { 
        }

        public AndamentoViewModel(Guid id, Guid pedidoId, DateTime dataHoraInicio, DateTime? dataHoraFim, Guid funcionarioId, int situacaoId, bool atual)
        {
            Id = id;
            PedidoId = pedidoId;
            DataHoraInicio = dataHoraInicio;
            DataHoraFim = dataHoraFim;
            FuncionarioId = funcionarioId;
            SituacaoId = situacaoId;
            Atual = atual;
        }

    }
}
