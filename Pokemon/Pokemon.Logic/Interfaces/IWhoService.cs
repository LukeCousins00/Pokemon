namespace Pokemon.Logic.Interfaces;

public interface IWhoService
{
    Task<List<string>> GetPokemonChoicesAsync(int maxChoices, List<int> generation, int seed);
}
