using to_do_list.Models;

namespace to_do_list.ViewModel
{
    public class ListTodoViewModel
    {
        public ICollection<Todo> Todos { get; set; } = new List<Todo>();
    }
}
