using System.Text.Json.Serialization;

namespace Pokemon.Models.PokemonModels.Physical;

public class PokemonSprite
{
    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }
}

