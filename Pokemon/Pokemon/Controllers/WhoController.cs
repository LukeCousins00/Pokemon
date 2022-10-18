using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Pokemon.Logic.Interfaces;
using Pokemon.Logic.Models.PokeApi;
using Pokemon.MemoryCache;
using Pokemon.ViewModels;

namespace Pokemon.Controllers;

public class WhoController : Controller
{
    private readonly IPokeApiService _pokeApiService;
    private readonly IWhoService _whoService;
    private IMemoryCache _memoryCache;

    private const int MAX_CHOICES = 4;

    public WhoController(IPokeApiService pokeApiService, IWhoService whoService, IMemoryCache memoryCache)
    {
        _pokeApiService = pokeApiService;
        _whoService = whoService;
        _memoryCache = memoryCache;
    }

    public async Task<(List<int>?, int?)> GetCachedDataAsync(string key)
    {

        if (key.ToLower().Contains("generation"))
        {
            List<int> cachedValue = await _memoryCache.GetOrCreateAsync<List<int>>(
                CacheKeys.Generations,
                cacheEntry =>
                {
                    return Task.FromResult(new List<int>() { 1 });
                });

            return (cachedValue, null);
        }
        else
        {
            int cachedValue = await _memoryCache.GetOrCreateAsync(key, cacheEntry =>
            {
                return Task.FromResult(0);
            });

            return (null, cachedValue);
        }
    }

    public async void SetCachedData(string key, int value)
    {
        // Update Generations
        if (key.ToLower().Contains("gen"))
        {
            (List<int> generations, _) = await GetCachedDataAsync(CacheKeys.Generations);

            if (generations.Contains(value))
            {
                generations.Remove(value);
            }
            else
            {
                generations.Add(value);
            }

            _memoryCache.Set(CacheKeys.Generations, generations);
        }
        // Update All Time Score Tracker
        if (key.ToLower().Contains("score")){
            (_, int? score) = await GetCachedDataAsync(CacheKeys.AllTimeScore);

            score++;
            _memoryCache.Set(CacheKeys.AllTimeScore, score);
        }
        // Set the new personal best
        else
        {
            _memoryCache.Set(CacheKeys.PersonalBest, value);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Index(int? sessionScore)
    {
        // page loading, get cache to find Generations/Scores
        (List<int> generations, _) = await GetCachedDataAsync(CacheKeys.Generations);
        (_,int? score) = await GetCachedDataAsync(CacheKeys.AllTimeScore);
        (_, int? personalBest) = await GetCachedDataAsync(CacheKeys.PersonalBest);

        int seed = Guid.NewGuid().GetHashCode();

        (List<string> choices, string answer) = await GetChoicesAndAnswerAsync(MAX_CHOICES, seed);

        PokemonPhysical physicalResponse = await _pokeApiService.GetPokemonPhysicalAsync(answer);

        WhoViewModel viewModel = new WhoViewModel
        {
            Choices = choices,
            SpriteUrl = physicalResponse.spriteUrl.Other.OfficialArtwork.FrontDefault,
            Generations = generations,
            SelectedPokemon = answer,
            Seed = seed,
            AllTimeScore = score.Value,
            PersonalBest = personalBest.Value,
        };

        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> ValidateAnswer(string userAnswer, int seed)
    {
        (List<int> generations, _) = await GetCachedDataAsync(CacheKeys.Generations);
        (_, string answer) = await GetChoicesAndAnswerAsync(MAX_CHOICES, seed);

        return Json(userAnswer == answer);
    }

    public async Task<(List<string>, string)> GetChoicesAndAnswerAsync(int maxChoices, int seed)
    {
        (List<int> generations, _) = await GetCachedDataAsync(CacheKeys.Generations);

        List<string> chosenPokemon = await _whoService.GetPokemonChoicesAsync(MAX_CHOICES, generations, seed);

        var random = new Random(seed);

        string selectedPokemon = chosenPokemon[random.Next(MAX_CHOICES)];

        return (chosenPokemon, selectedPokemon);
    }
}