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
    public PokemonSprite Sprite { get; set; }
}


