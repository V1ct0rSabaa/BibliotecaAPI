namespace PrimeiraAPI.DTO.BookDTO;

public record BookCreateDTO
{
    public string Title { get; set; } = String.Empty;
    public int AuthorId { get; set; }
    public List<string> Genres { get; set; } = [];
}
