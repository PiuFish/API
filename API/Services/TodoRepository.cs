using API.Models;

namespace API.Services
{
    public class TodoRepository
    {
        private readonly List<TodoItem> _items = new();
        private int _nextId = 1;

        public List<TodoItem> GetAll() => _items;
        public TodoItem? Get(int id) => _items.FirstOrDefault(x => x.Id == id);

        public TodoItem Add(TodoItem item)
        {
            item.Id = _nextId++;
            _items.Add(item);
            return item;
        }

        public bool Delete(int id)
        {
            var item = Get(id);
            if (item == null) return false;
            _items.Remove(item);
            return true;
        }

        public bool Update(int id, TodoItem item)
        {
            var existing = Get(id);
            if (existing == null) return false;
            existing.Name = item.Name;
            existing.IsComplete = item.IsComplete;
            return true;
        }
    }
}
