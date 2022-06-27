namespace Pokemon.Clients
{
    public interface IPokemonClient
    {
        Task<List<string>> GetEggGroupsAsync(string pokemonName);

        Task<int> GetPokemonHeightAsync(string pokemonName);

        Task<int> GetPokemonWeightAsync(string pokemonName);
        Task<string> GetPokemonSpriteAsync(string pokemonName);
    }
}