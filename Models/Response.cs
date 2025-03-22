
namespace PrimeiraAPI.Models;

public class Response<T>
{
    public T? Data {get; set;}
    public string Text { get; set; } = string.Empty;
    public bool Status { get; set; } = true;
}