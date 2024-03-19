using FastFoodProducao.Application.InputModels;
using GenericPack.Messaging;

namespace FastFoodProducao.Application.Interfaces
{
    public interface IAndamentoApp
    {
        Task<CommandResult> Add(AndamentoInputModel model);      
        
    }
}
