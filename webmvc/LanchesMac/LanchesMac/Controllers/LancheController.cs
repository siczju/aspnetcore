using LanchesMac.Models;
using LanchesMac.Repositories;
using LanchesMac.Repositories.Interfaces;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        public LancheController(ILancheRepository lancheRepository) {
            _lancheRepository = lancheRepository;
        }

        // listar os lanches
        // Como eu n informei o nome da view ele vai procurar uma
        // view com o nome do método (List)
        public IActionResult List()
        {
            ViewData["Titulo"] = "Todos os Lanches";
            ViewBag.FeitoPorJulio = "Feito por Juliao Lanches";

            //var lanches = _lancheRepository.Lanches; // retorna lista de todos lanches

            var lanchesListViewModel = new LancheListViewModel();
            lanchesListViewModel.Lanches = _lancheRepository.Lanches;
            lanchesListViewModel.CategoriaAtual = "Categoria Atual";

            TempData["QtdeLanche"] = lanchesListViewModel.Lanches.Count();

            return View(lanchesListViewModel);
        }
    }
}
