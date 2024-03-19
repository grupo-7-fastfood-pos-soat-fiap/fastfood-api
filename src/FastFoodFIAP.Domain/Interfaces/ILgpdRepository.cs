using FastFoodFIAP.Domain.Models;
using FastFoodFIAP.Domain.Models.PedidoAggregate;
using FastFoodFIAP.Domain.Models.ProdutoAggregate;
using GenericPack.Data;

namespace FastFoodFIAP.Domain.Interfaces
{
    public interface ILgpdRepository : IRepository<LgpdCliente>
    {
        void Add(LgpdCliente lgpdCliente);
        Task<IEnumerable<LgpdCliente>> GetAll();
        Task<LgpdCliente?> GetById(Guid id);
    }
}
