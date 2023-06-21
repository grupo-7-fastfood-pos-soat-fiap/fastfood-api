
using FastFoodFIAP.Domain.Models.ProdutoAggregate;
using GenericPack.Data;

namespace FastFoodFIAP.Domain.Interfaces
{
    public interface IProdutoRepository: IRepository<Produto>
    {
        Task<Produto?> GetById(int id);
        Task<IEnumerable<Produto>> GetAll();
        Task<IEnumerable<Produto>> GetAllByCategoria(int categoriaId);
        void Add(Produto produto);
        void Update(Produto produto);
        void Remove(Produto produto);
    }
}