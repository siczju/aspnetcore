using LanchesMac.Models;
using LanchesMac.Repositories.Interfaces;

namespace LanchesMac.ViewModels
{
    public class CarrinhoCompraViewModel
    {
        public CarrinhoCompra CarrinhoCompra { get; set; }
        public decimal CarrinhoCompraTotal { get; set; }
    }
}
