using Pokemon.Models.PokemonModels;
using System.Text.Json;
using Pokemon.Controllers;
using Pokemon.Models;

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
        
        // speciesResponse.IsSuccessStatusCode

        PokemonSpecies species = JsonSerializer.Deserialize<PokemonSpecies>(await speciesResponse.Content.ReadAsStringAsync());

        List<string> eggGroups = species.EggGroups.Select(x => x.Name).ToList();

        return eggGroups;
    }
}
