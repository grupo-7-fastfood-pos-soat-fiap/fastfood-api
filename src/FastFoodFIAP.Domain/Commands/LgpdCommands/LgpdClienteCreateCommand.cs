using FastFoodFIAP.Domain.Commands.LgpdCommands;
using FastFoodFIAP.Domain.Commands.LgpdCommands.Validations;

namespace FastFoodFIAP.Domain.Commands.LgpdCommands
{
    public class LgpdClienteCreateCommand : LgpdClienteCommand
    {
        protected LgpdClienteCreateCommand(){}

        public LgpdClienteCreateCommand(string nome, string telefone, string endereco, Boolean removerInformacoesPagamento)
        {
            Nome=nome;
            Telefone=telefone;
            Endereco=endereco;
            RemoverInformacoesPagamento = removerInformacoesPagamento;
        }

        public override bool IsValid()
        {
            CommandResult.ValidationResult = new LgpdClienteValidationsCreate().Validate(this);
            return CommandResult.ValidationResult.IsValid;
        }
    }
}