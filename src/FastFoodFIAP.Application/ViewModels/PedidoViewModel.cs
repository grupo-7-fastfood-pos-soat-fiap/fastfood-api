﻿namespace FastFoodFIAP.Application.ViewModels
{
    public class PedidoViewModel
    {
        public Guid Id { get; set; }
        public long CodigoAcompanhamento { get; set; }
        public ClienteViewModel? Cliente {get; set;}
        public List<PedidoComboViewModel>? Combos {get; set;}
    }
}
