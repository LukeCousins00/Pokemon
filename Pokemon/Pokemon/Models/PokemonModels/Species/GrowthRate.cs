﻿using System.Text.Json.Serialization;

namespace Pokemon.Models.PokemonModels.Species;

public class GrowthRate
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}