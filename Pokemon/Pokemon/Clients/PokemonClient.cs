using Pokemon.Models.PokemonModels.Species;
using System.Text.Json;
using System.Net.Http;
using Pokemon.Models.PokemonModels;

namespace Pokemon.Clients;

public class PokemonClient : IPokemonClient
{
    private readonly HttpClient _client;
    PokeApiNet.PokeApiClient pokeClient = new PokeApiNet.PokeApiClient();

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

    public async Task<PokemonPhysical> GetPokemonPhysicalAsync(string pokemonName)
    {
        pokemonName = pokemonName.ToLower();

        HttpResponseMessage physicalResponse = await _client.GetAsync($"/api/v2/pokemon/{pokemonName}");

        if (!physicalResponse.IsSuccessStatusCode)
        {
            throw new Exception("Failed to get response from pokeapi");
        }

        PokemonPhysical physical = JsonSerializer.Deserialize<PokemonPhysical>(await physicalResponse.Content.ReadAsStringAsync());

        return physical;
    }

    public async Task<PagedResponse<PokemonName>> GetPagedPokemonAsync(int pageLimit, int? offset)
    {
        HttpResponseMessage pagedResponse = await _client.GetAsync($"/api/v2/pokemon/?limit={pageLimit}&offset={offset}");

        if (!pagedResponse.IsSuccessStatusCode)
        {
            throw new Exception("Failed to get response from pokeapi");
        }

        PagedResponse<PokemonName> paged = JsonSerializer.Deserialize<PagedResponse<PokemonName>>(await pagedResponse.Content.ReadAsStringAsync(), new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        });

        return paged;
    }
}