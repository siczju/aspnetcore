using System.ComponentModel.DataAnnotations;

namespace to_do_list.ViewModel
{
    public class FormTodoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        [StringLength(100, ErrorMessage = "O título deve ter no máximo 100 caracteres")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "A data é obrigatória")]
        public DateTime Date { get; set; }
    }
}