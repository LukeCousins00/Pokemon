﻿using Pokemon.Logic.Models.PokeApi;

namespace Pokemon.ViewModels;


public class HomeViewModel
{
    public List<PokemonPhysical> PokemonData { get; set; }
    public int Count { get; set; }
    public int PageSize { get; set; }
}
