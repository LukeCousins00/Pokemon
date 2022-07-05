using System.Text.Json.Serialization;

namespace Pokemon.Models.PokemonModels;

public class PokemonSprite
{
    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }
}
