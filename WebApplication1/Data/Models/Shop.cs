using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models;

public class Shop
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(Order = 1)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public IEnumerable<Book> Books { get; set; }
    public IEnumerable<Order> Orders { get; set; }
}