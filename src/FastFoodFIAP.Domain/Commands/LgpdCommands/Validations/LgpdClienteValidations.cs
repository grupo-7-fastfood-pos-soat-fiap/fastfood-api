using FluentValidation;

namespace FastFoodFIAP.Domain.Commands.LgpdCommands.Validations
{
    public abstract class LgpdClienteValidations<T> : AbstractValidator<T> where T : LgpdClienteCommand
    {    
        protected void ValidaNome()
        {
            RuleFor(cliente => cliente.Nome)
                .Length(3, 100)
                .WithMessage("O Nome do cliente deve ter entre 3 e 100 caracteres");            
        }
        
        protected void ValidaTelefone()
        {
            RuleFor(cliente => cliente.Telefone)
                .NotEqual(String.Empty)
                .WithMessage("O Telefone não foi informado");

            RuleFor(cliente => cliente.Telefone)
                .MaximumLength(15)
                .WithMessage("O Telefone deve ter no máximo 15 caracteres");

        }

        protected void ValidaEndereco()
        {
            RuleFor(cliente => cliente.Endereco)
                .NotEqual(String.Empty)
                .WithMessage("O Endereço não foi informado");

            RuleFor(cliente => cliente.Endereco)
                .Length(3, 100)
                .WithMessage("O Endereço deve ter entre 3 e 100 caracteres");
        }


    }
}