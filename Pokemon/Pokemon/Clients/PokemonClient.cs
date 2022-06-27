using Pokemon.Models.PokemonModels.Pokemon;
using Pokemon.Models.PokemonModels.PokemonSpecies.PokemonSpecies;
using System.Text.Json;

namespace Pokemon.Clients;

public class PokemonClient : IPokemonClient
{
    private readonly HttpClient _client;

    public PokemonClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<string>> GetEggGroupsAsync(string pokemonName)
    {
        pokemonName = pokemonName.ToLower();

        HttpResponseMessage speciesResponse = await _client.GetAsync($"/api/v2/pokemon-species/{pokemonName}");
        
        if (!speciesResponse.IsSuccessStatusCode)
        {
            throw new Exception("Failed to get response from pokeapi");
        }

        PokemonSpecies species = JsonSerializer.Deserialize<PokemonSpecies>(await speciesResponse.Content.ReadAsStringAsync());

        List<string> eggGroups = species.EggGroups.Select(x => x.Name).ToList();

        return eggGroups;
    }

    public async Task<int> GetPokemonHeightAsync(string pokemonName)
    {
        pokemonName = pokemonName.ToLower();

        HttpResponseMessage physicalResponse = await _client.GetAsync($"/api/v2/pokemon/{pokemonName}");

        if (!physicalResponse.IsSuccessStatusCode)
        {
            throw new Exception("Failed to get response from pokeapi");
        }

        PokemonPhysical physical = JsonSerializer.Deserialize<PokemonPhysical>(await physicalResponse.Content.ReadAsStringAsync());

        int pokemonHeight = physical.PokemonHeight;

        return pokemonHeight;
    }

    public async Task<int> GetPokemonWeightAsync(string pokemonName)
    {
        pokemonName = pokemonName.ToLower();

        

        return (3);

    }

    public async Task<string> GetPokemonSpriteAsync(string pokemonName)
    {
        pokemonName = pokemonName.ToLower();

        return ("lol");
    }
}
