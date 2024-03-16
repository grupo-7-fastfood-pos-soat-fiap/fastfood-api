using AutoMapper;
using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.Interfaces;
using FastFoodFIAP.Application.ViewModels;
using FastFoodFIAP.Domain.Commands.LgpdCommands;
using FastFoodFIAP.Domain.Interfaces;
using FastFoodFIAP.Infra.Data.Repository;
using GenericPack.Mediator;
using GenericPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodFIAP.Application.Services
{
    public class LgpdApp : ILgpdApp
    {
        private readonly ILgpdRepository _lgpdRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public LgpdApp(ILgpdRepository lgpdRepository, IMediatorHandler mediator, IMapper mapper)
        {
            _lgpdRepository = lgpdRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<List<LgpdClienteViewModel>> GetAll()
        {
            return _mapper.Map<List<LgpdClienteViewModel>>(await _lgpdRepository.GetAll());
        }

        public async Task<CommandResult> AddLgpdCliente(LgpdClienteInputModel model)
        {
            var command = _mapper.Map<LgpdClienteCreateCommand>(model);
            return await _mediator.SendCommand(command);
        }

        public async Task<LgpdClienteViewModel> GetById(Guid id)
        {
            return _mapper.Map<LgpdClienteViewModel>(await _lgpdRepository.GetById(id));
        }
    }
}
