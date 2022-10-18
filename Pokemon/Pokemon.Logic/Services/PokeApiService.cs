using System.Text.Json;
using Pokemon.Logic.Interfaces;
using Pokemon.Logic.Models.PokeApi.Species;
using Pokemon.Logic.Models.PokeApi;
using Pokemon.Logic.Models.PokeApi.Generation;

namespace Pokemon.Logic.Services;

public class PokeApiService : IPokeApiService
{
    private readonly HttpClient _client;

    public PokeApiService(HttpClient client)
    {
        _client = client;
    }

    public string FirstLetterToUpper(string str)
    {
        if (str == null)
            return null;

        if (str.Length > 1)
            return char.ToUpper(str[0]) + str.Substring(1);

        return str.ToUpper();
    }

    public async Task<List<string>> GetPokemonByGenerationAsync(int generation)
    {

        HttpResponseMessage generationResponse = await _client.GetAsync($"/api/v2/generation/{generation}");

        if (!generationResponse.IsSuccessStatusCode)
        {
            throw new Exception("Failed to get response from pokeapi");
        }

        PokemonGeneration pokemonGeneration = JsonSerializer.Deserialize<PokemonGeneration>(await generationResponse.Content.ReadAsStringAsync());

        List<string> pokemonNames = pokemonGeneration.Species.Select(x => x.Name).ToList();

        return pokemonNames;
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

        physical.Name = FirstLetterToUpper(physical.Name);

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