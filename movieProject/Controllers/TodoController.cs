using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using movieProject.Models;
using movieProject.Models.Movie;
using movieProject.Models.Product;
using movieProject.Models.Todo;

namespace movieProject.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoRepository repo;
        public TodoController(ITodoRepository repo)
        {
            this.repo = repo;
        }

        // GET: TodoController
        public ActionResult Index()
        {
            var todo = repo.GetAllTodo();
            return View(todo);
        }

        // GET: TodoController/Details/5
        public ActionResult Details(int id)
        {
            var todo = repo.GetIdTodo(id);
            return View(todo);
        }

        // GET: TodoController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPut]
        public ActionResult UpdateTodo(int id)
        {
            var todo = repo.GetIdTodo(id);
            var newTodo = new TodoModel()
            {
                Id = todo.Id,
                Name = todo.Name,
                IsComplete = true
            };
            repo.PutTodo(newTodo);
            return RedirectToAction("Index");
        }

        // POST: TodoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TodoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TodoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TodoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TodoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
