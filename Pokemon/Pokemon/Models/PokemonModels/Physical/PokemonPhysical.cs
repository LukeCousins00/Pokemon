using System.Text.Json.Serialization;

namespace Pokemon.Models.PokemonModels.Physical;

public class PokemonPhysical
{
    [JsonPropertyName("height")]
    public int PokemonHeight { get; set; }

    [JsonPropertyName("weight")]
    public int PokemonWeight { get; set; }

    [JsonPropertyName("sprites")]
    public PokemonSprite PokemonSprite { get; set; }
}


