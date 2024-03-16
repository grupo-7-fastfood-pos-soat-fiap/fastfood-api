using AutoMapper;
using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.Interfaces;
using FastFoodFIAP.Application.ViewModels;
using FastFoodFIAP.Domain.Commands.PedidoCommands;
using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Domain.Interfaces.Services;
using FastFoodFIAP.Infra.Data.Mensageria;
using GenericPack.Mediator;
using GenericPack.Messaging;
using Microsoft.IdentityModel.Tokens;

namespace FastFoodFIAP.Application.Services
{
    public class PedidoApp : IPedidoApp
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;
        private readonly IProxyProducao _proxy;        

        public PedidoApp(IPedidoRepository pedidoRepository, IMediatorHandler mediator, IMapper mapper, IProxyProducao proxy)
        {
            _pedidoRepository = pedidoRepository;
            _mediator = mediator;
            _mapper = mapper;
            _proxy = proxy;
        }

        public async Task<CommandResult> Add(PedidoInputModel model)
        {
            var command = _mapper.Map<PedidoCreateCommand>(model);
            await PedidoMensageria.SendMessage("https://sqs.us-east-1.amazonaws.com/381491906285/pedidos-criados", command.ToString();
            return await _mediator.SendCommand(command);
        }

        public async Task<CommandResult> Update(Guid id, PedidoInputModel model)
        {
            var command = _mapper.Map<PedidoUpdateCommand>(model);
            command.SetId(id);
            return await _mediator.SendCommand(command);
        }

        public async Task<CommandResult> Remove(Guid id)
        {
            var command = new PedidoDeleteCommand(id);
            return await _mediator.SendCommand(command);
        }

        public async Task<List<PedidoViewModel>> GetAll()
        {
            return _mapper.Map<List<PedidoViewModel>>(await _pedidoRepository.GetAll());
        }

        public async Task<List<PedidoViewModel>> GetAllAtivos()
        {
            List<Guid> lista = new List<Guid>();

            var response = await _proxy.AndamentosAtivos();

            if (!response.IsNullOrEmpty())
                foreach (var item in response)
                    lista.Add(item.PedidoId);

            return _mapper.Map<List<PedidoViewModel>>(await _pedidoRepository.GetAllAtivos(lista));            
        }

        public async Task<List<PedidoViewModel>> GetAllBySituacao(int situacaoId)
        {
            List<Guid> lista = new List<Guid>();
            
            var response = await _proxy.AndamentosPorSituacao(situacaoId);

            if(!response.IsNullOrEmpty())
                foreach (var item in response)
                    lista.Add(item.PedidoId);

            return _mapper.Map<List<PedidoViewModel>>(await _pedidoRepository.GetAllBySituacao(lista));
        }

        public async Task<PedidoViewModel> GetById(Guid id)
        {
            return _mapper.Map<PedidoViewModel>(await _pedidoRepository.GetById(id));
        }        

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
