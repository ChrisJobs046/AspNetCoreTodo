using System;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;
using System.Collections.Generic;

namespace AspNetCoreTodo.Services
{
    public class FakeTodoItemService : ITodoItemService
    {
        public Task<bool> AddItemAsync(TodoItem newItem)
        {
            throw new NotImplementedException();
        }

        public Task<TodoItem[]> GetIncompleteItemsAsync()
        {
            var item = new TodoItem{

                Title = "Learn Asp.Net Core",
                DueAt = DateTimeOffset.Now.AddDays(1)
            };

            var item2 = new TodoItem{

                Title = "Build Awesome Apps",
                DueAt = DateTimeOffset.Now.AddDays(2)
            };

            return Task.FromResult( new[] { item, item2 });
        }
    }
}