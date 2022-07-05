using System.Text.Json.Serialization;

namespace Pokemon.Logic.Models.PokeApi;

public class PokemonSprite
{
    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }
}
