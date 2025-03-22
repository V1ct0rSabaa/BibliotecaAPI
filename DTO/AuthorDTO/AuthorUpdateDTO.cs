namespace PrimeiraAPI.DTO.AuthorDTO;

public record AuthorUpdateDTO(int Id, string Name = "", string Lastname = "", string Nationality = "");
