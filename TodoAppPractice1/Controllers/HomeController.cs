using Microsoft.AspNetCore.Mvc;
using TodoAppPractice1.Models;

namespace TodoAppPractice1.Controllers
{
    public class HomeController : Controller
    {
        private static List<TodoItems> todosList = new List<TodoItems>();
        //{
        //    //new TodoItems() { ID = 1, Task = "Learn new Topic", IsComplete = false },
        //    //new TodoItems() { ID = 2, Task = "Sleep on Time", IsComplete = true },
        //    //new TodoItems() { ID = 3, Task = "Try to learn a new skill.", IsComplete = false }
        //};

        private static int nextId = 1;

        [Route("")]
        public IActionResult Index()
        {
            return View(todosList);
        }

        [Route("add")]
        public IActionResult Add(string task)
        {

            todosList.Add(new TodoItems() { ID = nextId++, Task = task, IsComplete = false });

            return RedirectToAction("Index");
        }

        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {

            var deleteItem = todosList.FirstOrDefault(x => x.ID == id);

            if(deleteItem != null)
            {
                todosList.Remove(deleteItem);
            }

            return RedirectToAction("Index");
        }

    }
}
