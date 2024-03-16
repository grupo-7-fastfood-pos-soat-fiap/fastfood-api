using System.ComponentModel.DataAnnotations;

namespace FastFoodFIAP.Application.ViewModels
{
    public class LgpdClienteViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        
        public string Endereco { get; set; }

        public string Telefone { get; set; }

        public Boolean RemoverInformacoesPagamento { get; set; }

    }
}