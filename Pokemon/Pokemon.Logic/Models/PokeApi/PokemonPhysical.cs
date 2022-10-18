using Pokemon.Logic.Models.PokeApi.Sprite;
using System.Text.Json.Serialization;

namespace Pokemon.Logic.Models.PokeApi;

public class PokemonPhysical
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("weight")]
    public int Weight { get; set; }

    [JsonPropertyName("sprites")]
    public Sprites spriteUrl { get; set; }
}


