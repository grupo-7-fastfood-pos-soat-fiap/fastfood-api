using FastFoodFIAP.Domain.Models.PedidoAggregate;
using GenericPack.Data;

namespace FastFoodFIAP.Domain.Interfaces
{
    public interface IPedidoRepository: IRepository<Pedido>
    {
        Task<Pedido?> GetById(Guid id);
        Task<IEnumerable<Pedido>> GetAll();
        Task<IEnumerable<Pedido>> GetAllAtivos(List<Guid> lista);
        Task<IEnumerable<Pedido>> GetAllBySituacao(List<Guid> lista);
        void Add(Pedido pedido);
        void Update(Pedido pedido);
        void Remove(Pedido pedido);
    }
}
