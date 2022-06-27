using System.Text.Json.Serialization;

namespace Pokemon.Models.PokemonModels.PokemonSpecies.PokemonSpecies;

public class Variety
{
    [JsonPropertyName("is_default")]
    public bool IsDefault { get; set; }

    [JsonPropertyName("pokemon")]
    public Pokemon Pokemon { get; set; }
}
