namespace WebApplication1.Data.DTOs;

public class OrderDTO
{
    public int Id { get; set; }
    public string goods { get; set; }
    public int cost { get; set; }
    public int[] books { get; set; }
    public int[] shops { get; set; }
    public int[] users { get; set; }
}