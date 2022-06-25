﻿using System.Text.Json.Serialization;

namespace Pokemon.Models.PokemonModels;

public class PokemonSpeciesName
{

    [JsonPropertyName("language")]
    public Language Language { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}
