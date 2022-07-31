using Microsoft.EntityFrameworkCore;
using Pokemon.Logic.Interfaces;
using Pokemon.Logic.Models.PokeApi;

namespace Pokemon.Logic.Services;

public class WhoService : IWhoService
{
    private readonly IPokeApiService _pokeApiService;

    public WhoService(IPokeApiService pokeApiService)
    {
        _pokeApiService = pokeApiService;   
    }

    public string FirstLetterToUpper(string str)
    {
        if (str == null)
            return null;

        if (str.Length > 1)
            return char.ToUpper(str[0]) + str.Substring(1);

        return str.ToUpper();
    }

    public async Task<List<string>> GetPokemonChoicesAsync(int maxChoices, List<int> generation, int seed)
    {
        List<string> pokemonSpecies = new List<string>();

        foreach (int pokemonGeneration in generation)
        {
            List<string> generationSpecies = await _pokeApiService.GetPokemonByGenerationAsync(pokemonGeneration);
            pokemonSpecies.AddRange(generationSpecies);
        }

        var random = new Random(seed);

        List<int> choices = new List<int>();

        while (choices.Count < maxChoices)
        {
            int randomIndex = random.Next(pokemonSpecies.Count() - 1);

            if (!choices.Contains(randomIndex))
                choices.Add(randomIndex);

        }

        List<string> chosenPokemon = pokemonSpecies.Where((ps, i) => choices.Contains(i)).ToList();

        for (int i = 0; i < chosenPokemon.Count(); i++)
        {
            chosenPokemon[i] = FirstLetterToUpper(chosenPokemon[i]);
        }

        return chosenPokemon;
    }
}
