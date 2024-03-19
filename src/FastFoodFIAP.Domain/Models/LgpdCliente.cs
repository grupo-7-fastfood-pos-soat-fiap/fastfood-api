using FastFoodFIAP.Domain.Models.PedidoAggregate;
using GenericPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodFIAP.Domain.Models
{
    public class LgpdCliente : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public string Endereco { get; private set; }
        public bool RemoverInformacoesPagamento { get; private set; }


        private LgpdCliente()
        {
            
        }

        public LgpdCliente(Guid id, string nome, string telefone, string endereco, bool removerInformacoesPagamento)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            Endereco = endereco;
            RemoverInformacoesPagamento = removerInformacoesPagamento;


        }

    }
}
