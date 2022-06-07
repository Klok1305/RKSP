namespace WebApplication1.Data.DTOs;

public class BookDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public string Genre { get; set; }
    //public string AuthorName { get; set; }
    //public int AuthorID { get; set; }
    public int[] Orders { get; set; }
    public int[] Shops { get; set; }
    public int[] Authors { get; set; } 
}