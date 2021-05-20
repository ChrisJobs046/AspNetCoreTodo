using Microsoft.AspNetCore.Mvc;
using AspNetCoreTodo.Services;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Controllers
{
    public class TodoController: Controller
    {
        private readonly ITodoItemService _todoItemService;

        public TodoController(ITodoItemService todoItemService){

            _todoItemService = todoItemService;
        }
        public async Task<IActionResult> Index(){

            var items = await _todoItemService.GetIncompleteItemsAsync();

            var model = new TodoViewModel(){

                Items = items
            };

            return View(model);

            // Obtener las tareas desde la base de datos

            // Colocar los tareas en un modelo

            // Genera la vista usando el modelo
        }
        
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(TodoItem newItem){

            if(!ModelState.IsValid){

                return RedirectToAction("Index");
            }

            var correcto = await _todoItemService.AddItemAsync(newItem);

            if(!correcto){
                return BadRequest("Could not add itemm");
            }

            return RedirectToAction("Index");

        }
    }


}