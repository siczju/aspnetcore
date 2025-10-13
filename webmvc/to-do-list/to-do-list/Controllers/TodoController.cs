using Microsoft.AspNetCore.Mvc;
using to_do_list.Contexts;
using to_do_list.ViewModel;
using to_do_list.Models;
using Microsoft.EntityFrameworkCore;

namespace to_do_list.Controllers
{
    public class TodoController : Controller
    {
        private readonly AppDbContext _context;

        public TodoController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index() // listagem de tarefas
        {
            var todos = await _context.Todos.OrderBy(x => x.Date).ToListAsync(); // ordenação pela data
            var viewModel = new ListTodoViewModel { Todos = todos };
            ViewData["Title"] = "Lista de Tarefas";
            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewData["Title"] = "Criar Tarefa";
            return View("Formulario");
        }

        [HttpPost]
        public async Task<IActionResult> Create(FormTodoViewModel data)
        {
            if(!ModelState.IsValid)
            {
                ViewData["Title"] = "Criar Tarefa";
                return View("Formulario", data);
            }

            try
            {
                _context.Add(new Todo(data.Title, data.Date));
                await _context.SaveChangesAsync();

                TempData["Success"] = "Tarefa criada com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception)
            {
                ModelState.AddModelError("", "Erro ao salvar a tarefa. Tente novamente.");
                ViewData["Title"] = "Criar Tarefa";
                return View("Formulario", data);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
                return BadRequest();

            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
                return NotFound();

            var viewModel = new FormTodoViewModel
            {
                Id = todo.Id,
                Title = todo.Title,
                Date = todo.Date
            };

            ViewData["Title"] = "Editar Tarefa";
            return View("Formulario", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(FormTodoViewModel data)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Title"] = "Editar Tarefa";
                return View("Formulario", data);
            }

            try
            {
                var todo = await _context.Todos.FindAsync(data.Id);
                if (todo == null)
                {
                    return NotFound();
                }

                todo.Title = data.Title;
                todo.Date = data.Date;

                await _context.SaveChangesAsync();
                TempData["Success"] = "Tarefa atualizada com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Erro ao atualizar a tarefa. Tente novamente");
                ViewData["Title"] = "Editar Tarefa";
                return View("Formulario", data);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            try
            {
                var todo = await _context.Todos.FindAsync(id);
                if (todo == null)
                    return NotFound();

                _context.Remove(todo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["Error"] = "Erro ao excluir a tarefa.";
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Complete(int id)
        {
            if (id <= 0)
                return BadRequest();

            try
            {
                var todo = await _context.Todos.FindAsync(id);
                if (todo == null)
                    return NotFound();

                todo.IsCompleted = !todo.IsCompleted;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["Error"] = "Erro ao atualizar o status da tarefa.";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
