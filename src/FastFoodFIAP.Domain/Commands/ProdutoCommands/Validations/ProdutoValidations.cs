using FluentValidation;

namespace FastFoodFIAP.Domain.Commands.ProdutoCommands.Validations
{
    public abstract class ProdutoValidations<T> : AbstractValidator<T> where T : ProdutoCommand
    {
        protected void ValidaId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("O Id do produto não foi informado");
        }

        protected void ValidaNome()
        {
            RuleFor(c => c.Nome)
                .Length(3, 100)
                .WithMessage("O Nome do produto deve ter entre 3 e 100 caracteres");
        }

        protected void ValidaDescricao()
        {
            RuleFor(c => c.Descricao)
                .Length(3, 100)
                .WithMessage("A Descrição do produto deve ter entre 3 e 1000 caracteres");
        }

        protected void ValidaPreco()
        {
            RuleFor(c => c.Preco)
                .GreaterThan(0).WithMessage("O Preço do produto deve ser maior que zero");
        }

        protected void ValidaCategoria()
        {
            RuleFor(c => c.CategoriaId)
                .NotEqual(Guid.Empty)
                .WithMessage("A Categoria do produto não foi informada");
        }

        protected void ValidaExisteImagem()
        {
            RuleFor(c => c.ImagensUrl.Count)
                .GreaterThan(0)
                .WithMessage("O produto deve possuir pelo menos uma imagem");
        }
    }
}