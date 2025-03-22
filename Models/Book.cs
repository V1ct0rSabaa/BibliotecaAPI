namespace PrimeiraAPI.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public required Author Author { get; set; }
    public List<string> Genres { get; set; } = [];
}