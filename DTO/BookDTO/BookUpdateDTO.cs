namespace PrimeiraAPI.DTO.BookDTO;

public record BookUpdateDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public int? AuthorId { get; set; } // O AuthorId pode ser opcional caso o autor não precise ser atualizado

}