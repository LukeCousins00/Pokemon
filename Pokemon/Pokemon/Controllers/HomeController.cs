using Microsoft.AspNetCore.Mvc;
using Pokemon.Logic.Interfaces;
using Pokemon.Logic.Models.PokeApi;
using Pokemon.ViewModels;
using System.Diagnostics;


namespace Pokemon.Controllers;

public class HomeController : Controller
{
    private readonly IPokeApiService _pokeApiService;

    public HomeController(IPokeApiService pokeApiService)
    {
        _pokeApiService = pokeApiService;
    }

    [HttpGet]
    public async Task<IActionResult> Index([FromQuery(Name = "page")] int? pageNumber, int limit = 24)
    {
        pageNumber ??= 1;
        
        PagedResponse<PokemonName> pagedResponse = await _pokeApiService.GetPagedPokemonAsync(limit, ((pageNumber - 1) * limit));
        List<PokemonPhysical> pokemonPhysicals = new List<PokemonPhysical>();   

        // get pokemon physical
        foreach (var pokemon in pagedResponse.Results)
        {
            PokemonPhysical pokemonPhysical = await _pokeApiService.GetPokemonPhysicalAsync(pokemon.Name);

            PokemonPhysical physicalViewModel = new PokemonPhysical
            {
                Name = pokemonPhysical.Name,
                Height = pokemonPhysical.Height,
                Weight = pokemonPhysical.Weight,
                spriteUrl = pokemonPhysical.spriteUrl
            };

            pokemonPhysicals.Add(physicalViewModel);
        }

        HomeViewModel viewModel = new HomeViewModel
        {
            PokemonData = pokemonPhysicals,
            Count = pagedResponse.Count,
            PageSize = limit
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}