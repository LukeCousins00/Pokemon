namespace Pokemon.Logic.Models.PokeApi;

public class PagedResponse<T>
{
    public int Count { get; set; }
    public T[] Results { get; set; }
}