using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace to_do_list.Models;

[Table("todo")]
public class Todo
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("title", TypeName = "nvarchar(100)")]
    public string Title { get; set; } = string.Empty;

    [Required]
    [Column("date", TypeName = "date")]
    public DateTime Date { get; set; }

    [Required]
    [Column("is_completed", TypeName = "bit")]
    public bool IsCompleted { get; set; } = false;

    public Todo() { }

    public Todo(string title, DateTime date, bool isCompleted = false)
    {
        Title = title;
        Date = date;
        IsCompleted = isCompleted;
    }

    public Todo(int id, string title, DateTime date, bool isCompleted = false)
    {
        Id = id;
        Title = title;
        Date = date;
        IsCompleted = isCompleted;
    }
}