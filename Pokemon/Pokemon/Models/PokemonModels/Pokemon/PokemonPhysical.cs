using System.Text.Json.Serialization;

namespace Pokemon.Models.PokemonModels.Pokemon;

public class PokemonPhysical
{
    [JsonPropertyName("height")]
    public int PokemonHeight { get; set; }

    [JsonPropertyName("weight")]
    public int PokemonWeight { get; set; }

   // [JsonPropertyName("sprites")]
   // public string PokemonSprite { get; set; }
}


