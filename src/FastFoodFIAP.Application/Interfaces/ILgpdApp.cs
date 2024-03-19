using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.ViewModels;
using GenericPack.Messaging;

namespace FastFoodFIAP.Application.Interfaces
{
    public interface ILgpdApp : IDisposable
    {
        Task<CommandResult> AddLgpdCliente(LgpdClienteInputModel model);
        Task<List<LgpdClienteViewModel>> GetAll();
        Task<LgpdClienteViewModel> GetById(Guid id);
    }
}
