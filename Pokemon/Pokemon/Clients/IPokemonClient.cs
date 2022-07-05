using Pokemon.Models.PokemonModels;

namespace Pokemon.Clients
{
    public interface IPokemonClient
    {
        Task<List<string>> GetEggGroupsAsync(string pokemonName);
        Task<PokemonPhysical> GetPokemonPhysicalAsync(string pokemoName);
        Task<PagedResponse<PokemonName>> GetPagedPokemonAsync(int limit, int? offset);
    }
}