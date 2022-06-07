using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models;

public class Author
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(Order = 1)]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public IEnumerable<Book> Books { get; set; }
}

