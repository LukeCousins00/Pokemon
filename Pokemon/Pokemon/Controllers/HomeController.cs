using Microsoft.AspNetCore.Mvc;
using Pokemon.Clients;
using Pokemon.Logic;
using Pokemon.Models;
using System.Diagnostics;

namespace Pokemon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPokemonClient _pokemonClient;

        public HomeController(ILogger<HomeController> logger, IPokemonClient pokemonClient)
        {
            _logger = logger;
            _pokemonClient = pokemonClient;
        }

        // [HttpGet] by default
        public async Task<IActionResult> Index()
        {
            var lolz = new PokemonLogic();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string pokemon1, string pokemon2)
        {
            List<string> eggGroupPokemon1 = await _pokemonClient.GetEggGroupsAsync(pokemon1);
            List<string> eggGroupPokemon2 = await _pokemonClient.GetEggGroupsAsync(pokemon2);

            List<EggGroupViewModel> eggGroups = new List<EggGroupViewModel>
            {
                new EggGroupViewModel
                {
                    PokemonName = pokemon1,
                    EggGroups = eggGroupPokemon1
                },

                new EggGroupViewModel
                {
                    PokemonName = pokemon2,
                    EggGroups = eggGroupPokemon2
                }
            };

            List<string> matchingEggGroupNames = eggGroupPokemon1.Intersect(eggGroupPokemon2).ToList();

            HomeViewModel viewModel = new HomeViewModel
            {
                CanBreed = matchingEggGroupNames.Any(),
                EggGroups = eggGroups
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}