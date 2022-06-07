using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(Order = 1)]
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Order> Orders { get; set; }
}