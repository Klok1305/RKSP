using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models;

public class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(Order = 1)]

    public int Id { get; set; }
    public string Author { get; set; }
    public IEnumerable<Author> Authors { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    
}