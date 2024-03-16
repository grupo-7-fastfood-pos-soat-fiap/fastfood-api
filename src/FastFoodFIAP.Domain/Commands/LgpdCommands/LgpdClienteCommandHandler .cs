using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Models;
using FluentValidation.Results;
using GenericPack.Messaging;
using MediatR;

namespace FastFoodFIAP.Domain.Commands.LgpdCommands
{
    public class LgpdClienteCommandHandler : CommandHandler,
        IRequestHandler<LgpdClienteCreateCommand, CommandResult>
    {

        private readonly ILgpdRepository _repository;
        public LgpdClienteCommandHandler(IMediator mediator, ILgpdRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResult> Handle(LgpdClienteCreateCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.CommandResult;            
            
            var lgpdCliente = new LgpdCliente(Guid.NewGuid(), request.Nome, request.Telefone, request.Endereco, request.RemoverInformacoesPagamento);            
            
            _repository.Add(lgpdCliente);            

            return await Commit(_repository.UnitOfWork, lgpdCliente.Id);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}