namespace Pokemon.Clients
{
    public interface IPokemonClient
    {
        Task<List<string>> GetEggGroupsAsync(string pokemonName);

        Task<int> GetPokemonHeightAsync(string pokemonName);

        // Task<int> GetPokemonWeightAsync(string pokemonName);

        // For Getting pokemon sprites, want front_default Type string

        //Task<string> GetPokemonSpriteAsync(string pokemonName);
    }
}