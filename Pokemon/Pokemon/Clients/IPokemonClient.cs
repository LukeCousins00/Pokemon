namespace Pokemon.Clients
{
    public interface IPokemonClient
    {
        Task<List<string>> GetEggGroupsAsync(string pokemonName);
    }
}