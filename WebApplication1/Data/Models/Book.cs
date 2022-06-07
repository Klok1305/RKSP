using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models;

public class Book
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(Order = 1)]

    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string Genre { get; set; }
    //public string AuthorName { get; set; }
    //public int AuthorID { get; set; }
    public IEnumerable<Order> Orders { get; set; }
    public IEnumerable<Shop> Shops { get; set; }
    public IEnumerable<Author> Authors { get; set; }
}