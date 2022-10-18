using Microsoft.AspNetCore.Mvc;
using Pokemon.Logic.Interfaces;
using Pokemon.Logic.Models.PokeApi;
using Pokemon.ViewModels;

namespace Pokemon.Controllers;

public class BreedingController : Controller
{
    private readonly IPokeApiService _pokemonClient;

    public BreedingController(IPokeApiService pokemonClient)
    {
        _pokemonClient = pokemonClient;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(string pokemon1, string pokemon2)
    {
        List<string> eggGroupPokemon1 = await _pokemonClient.GetEggGroupsAsync(pokemon1);
        List<string> eggGroupPokemon2 = await _pokemonClient.GetEggGroupsAsync(pokemon2);

        PokemonPhysical pokemon1Physical = await _pokemonClient.GetPokemonPhysicalAsync(pokemon1);
        var spriteUrlPokemon1 = pokemon1Physical.spriteUrl;

        PokemonPhysical pokemon2Physical = await _pokemonClient.GetPokemonPhysicalAsync(pokemon2);
        var spriteUrlPokemon2 = pokemon2Physical.spriteUrl;



        List<EggGroupViewModel> eggGroups = new List<EggGroupViewModel>
            {
                new EggGroupViewModel
                {
                    PokemonName = pokemon1,
                    EggGroups = eggGroupPokemon1,
                    PokemonSpriteUrl = spriteUrlPokemon1.ToString()
                },

                new EggGroupViewModel
                {
                    PokemonName = pokemon2,
                    EggGroups = eggGroupPokemon2,
                    PokemonSpriteUrl = spriteUrlPokemon2.ToString()
                }
            };

        List<string> matchingEggGroupNames = eggGroupPokemon1.Intersect(eggGroupPokemon2).ToList();

        BreedingViewModel viewModel = new BreedingViewModel
        {
            CanBreed = matchingEggGroupNames.Any(),
            EggGroups = eggGroups
        };

        return View(viewModel);
    }
}
