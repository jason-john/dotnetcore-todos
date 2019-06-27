using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todos.Models;

namespace Todos
{
    public class TodosDataStore
    {
        public static TodosDataStore Current { get; } = new TodosDataStore();
        public List<TodoDto> Todos { get; set;  }

        public TodosDataStore()
        {
            Todos = new List<TodoDto>()
            {
                new TodoDto()
                {
                    Id = 1,
                    Title = "Walk the dog",
                    IsCompleted = false
                },
                new TodoDto()
                {
                    Id = 2,
                    Title = "Mow the yard",
                    IsCompleted = false
                },
                new TodoDto()
                {
                    Id = 3,
                    Title = "Clean the kitchen",
                    IsCompleted = false
                },
            };
        }

    }
}
