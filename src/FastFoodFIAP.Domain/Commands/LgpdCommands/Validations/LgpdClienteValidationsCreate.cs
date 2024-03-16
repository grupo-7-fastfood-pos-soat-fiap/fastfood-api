
namespace FastFoodFIAP.Domain.Commands.LgpdCommands.Validations
{
    public class LgpdClienteValidationsCreate:LgpdClienteValidations<LgpdClienteCreateCommand>
    {
        public LgpdClienteValidationsCreate(){            
            ValidaNome();
            ValidaTelefone();    
            ValidaEndereco();                    
        }
    }
}