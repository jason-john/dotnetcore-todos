using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todos.Controllers
{
    [Route("api/todos")]
    public class TodosController : Controller
    {
        [HttpGet()]
        public IActionResult GetTodos()
        {
            return Ok(TodosDataStore.Current.Todos);
        }
    }
}
