﻿using System.Text.Json.Serialization;

namespace Pokemon.Models.PokemonModels;

public class Shape
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}
