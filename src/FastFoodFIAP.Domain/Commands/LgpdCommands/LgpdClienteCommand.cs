using GenericPack.Messaging;

namespace FastFoodFIAP.Domain.Commands.LgpdCommands
{
    public abstract class LgpdClienteCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        
        public string Endereco { get; protected set; }

        public string Telefone { get; protected set; }

        public bool RemoverInformacoesPagamento { get; protected set; }
    }
}