using System.Data;
using AutoMapper;
using FastFoodFIAP.Application.InputModels;
using FastFoodFIAP.Application.ViewModels;
using FastFoodFIAP.Domain.Models;
using FastFoodFIAP.Domain.Models.PedidoAggregate;
using FastFoodFIAP.Domain.Models.ProdutoAggregate;

namespace FastFoodFIAP.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public DomainToViewModelMappingProfile()
        {
            AllowNullCollections = true;            

            CreateMap<CategoriaProduto, CategoriaProdutoViewModel>();

            CreateMap<Cliente, ClienteViewModel>();

            CreateMap<Imagem, ImagemViewModel>();

            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(c => c.Categoria,
                    map => map.MapFrom(m => m.CategoriaNavegation));

            CreateMap<Pagamento, PagamentoViewModel>()
                .ForMember(c => c.Situacao,
                    map => map.MapFrom(m => m.SituacaoPagamentoNavegation));

            CreateMap<Pedido, PedidoViewModel>()
                .ForMember(c => c.Cliente,
                    map => map.MapFrom(m => m.ClienteNavegation))
                .ForMember(c => c.Pagamento,
                    map => map.MapFrom(m => m.PagamentoNavegation));

            CreateMap<PedidoCombo, PedidoComboViewModel>();
            
            CreateMap<PedidoComboProduto, PedidoComboProdutoViewModel>()
                .ForMember( c => c.Produto,
                    map => map.MapFrom(m => m.ProdutoNavigation));
            
            CreateMap<Funcionario, FuncionarioViewModel>()
                .ForMember( c => c.Ocupacao,
                    map => map.MapFrom(m => m.OcupacaoNavegation));
            
            CreateMap<Ocupacao, OcupacaoViewModel>();            

            CreateMap<SituacaoPagamento, SituacaoPagamentoViewModel>();



        }
    }
}
