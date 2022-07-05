namespace Pokemon.Models.PokemonModels;

public class PagedResponse<T>
{
    public int Count { get; set; }
    public T[] Results { get; set; }
}