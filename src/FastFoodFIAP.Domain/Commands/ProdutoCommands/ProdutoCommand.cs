using GenericPack.Messaging;

namespace FastFoodFIAP.Domain.Commands.ProdutoCommands
{
    public abstract class ProdutoCommand: Command
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; } = "";
        public string Descricao { get; protected set; } = "";
        public decimal Preco { get; protected set; }
        public Guid CategoriaId {get; protected set;}
        public List<string> ImagensUrl{get; protected set;} 

        public ProdutoCommand(){
            ImagensUrl = new List<string>();
        }
    }
}