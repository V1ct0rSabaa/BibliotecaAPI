using System.Text.Json.Serialization;

namespace PrimeiraAPI.Models;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Lastname { get; set; } = String.Empty;
    public string Nationality { get; set; } = String.Empty;
    [JsonIgnore] // não precisamos informar todos os livros do autor ao add no sistema
    public List<Book> books { get; set; } = [];
    
}