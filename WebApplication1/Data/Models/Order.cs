using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models;

public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(Order = 1)]
    public int Id { get; set; }
    public string goods { get; set; }
    public int cost { get; set; }
    public IEnumerable<Book> Books { get; set; }
    public IEnumerable<Shop> Shops { get; set; }
    public IEnumerable<User> Users { get; set; }
}