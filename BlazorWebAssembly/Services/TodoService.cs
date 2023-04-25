using BlazorWebAssembly.Models;

namespace BlazorWebAssembly.Services
{
    public class TodoService
    {
        private List<TodoItem> _todoItems = new List<TodoItem>();

        public TodoService()
        {
            // Add some default todo items
            _todoItems.Add(new TodoItem { Id = 1, Title = "Learn Blazor", IsComplete = true });
            _todoItems.Add(new TodoItem { Id = 2, Title = "Build a Blazor Web Assembly App", IsComplete = false });
            _todoItems.Add(new TodoItem { Id = 3, Title = "Build a Blazor Server App", IsComplete = false });
        }

        public List<TodoItem> GetAll()
        {
            return _todoItems;
        }

        public TodoItem GetById(int id)
        {
            return _todoItems.FirstOrDefault(t => t.Id == id);
        }

        public void Add(TodoItem todoItem)
        {
            TodoItem item = _todoItems.OrderByDescending(t => t.Id).FirstOrDefault();
            if(item!= null)
            {
                todoItem.Id = item.Id + 1;
            }

            _todoItems.Add(todoItem);
        }

        public void Update(TodoItem todoItem)
        {
            var index = _todoItems.FindIndex(t => t.Id == todoItem.Id);
            _todoItems[index] = todoItem;
        }

        public void Delete(int id)
        {
            var todoItem = _todoItems.FirstOrDefault(t => t.Id == id);
            _todoItems.Remove(todoItem);
        }
    }
}
