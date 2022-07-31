using Pokemon.Logic.Models.PokeApi;

namespace Pokemon.Logic.Interfaces;

public interface IPokeApiService
{
    Task<List<string>> GetEggGroupsAsync(string pokemonName);
    Task<PokemonPhysical> GetPokemonPhysicalAsync(string pokemoName);
    Task<PagedResponse<PokemonName>> GetPagedPokemonAsync(int limit, int? offset);
    Task<List<string>> GetPokemonByGenerationAsync(int generation);
}