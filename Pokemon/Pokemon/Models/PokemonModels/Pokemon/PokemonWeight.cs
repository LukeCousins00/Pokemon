using System.Text.Json.Serialization;

namespace Pokemon.Models.PokemonModels.Pokemon;

public class PokemonWeight
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}

