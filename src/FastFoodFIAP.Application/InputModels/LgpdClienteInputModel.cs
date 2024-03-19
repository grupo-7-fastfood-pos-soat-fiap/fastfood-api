using System.ComponentModel.DataAnnotations;

namespace FastFoodFIAP.Application.InputModels
{
    public class LgpdClienteInputModel
    {
        public string Nome { get; set; }
        
        public string Endereco { get; set; }

        public string Telefone { get; set; }

        public Boolean RemoverInformacoesPagamento { get; set; }

    }
}