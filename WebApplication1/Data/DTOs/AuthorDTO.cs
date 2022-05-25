namespace WebApplication1.Data.DTOs;

public class AuthorDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Genre { get; set; }
    public int Age { get; set; }
    public int[] Affiliations { get; set; }
}   