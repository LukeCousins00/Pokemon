using Pokemon.Data.Entities;

namespace Pokemon.Logic.Interfaces;

public interface IPokemonService
{
    Task<PokemonDetail> AddPokemonDetailAsync(PokemonDetail pokemonDetail);
    Task<PokemonDetail?> GetPokemonDetailAsync(int id);
    Task<PokemonDetail?> GetPokemonDetailAsync(string name);
    Task<IEnumerable<PokemonDetail>> GetPokemonDetailsAsync();
}