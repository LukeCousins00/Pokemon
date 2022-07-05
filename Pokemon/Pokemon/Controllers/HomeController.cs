using Microsoft.AspNetCore.Mvc;
using Pokemon.Clients;
using Pokemon.Logic;
using Pokemon.Models.PokemonModels;
using Pokemon.ViewModels;
using System.Diagnostics;


namespace Pokemon.Controllers;

public class HomeController : Controller
{
    private readonly IPokemonClient _pokemonClient;

    public HomeController(IPokemonClient pokemonClient)
    {
        _pokemonClient = pokemonClient;
    }

    [HttpGet]
    public async Task<IActionResult> Index([FromQuery(Name = "page")] int? pageNumber, int limit = 24)
    {
        if (pageNumber == null)
        {
            pageNumber = 1;
        }

        PagedResponse<PokemonName> pagedResponse = await _pokemonClient.GetPagedPokemonAsync(limit, ((pageNumber - 1) * limit));
        List<PokemonPhysical> pokemonPhysicals = new List<PokemonPhysical>();   

        // get pokemon physical
        foreach (var pokemon in pagedResponse.Results)
        {
            PokemonPhysical pokemonPhysical = await _pokemonClient.GetPokemonPhysicalAsync(pokemon.Name);

            PokemonPhysical physicalViewModel = new PokemonPhysical
            {
                Name = pokemon.Name,
                Height = pokemonPhysical.Height,
                Weight = pokemonPhysical.Weight,
                Sprite = pokemonPhysical.Sprite
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