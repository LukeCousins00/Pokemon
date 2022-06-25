using System.Text.Json.Serialization;

namespace Pokemon.Models.PokemonModels;

public class EvolutionChain
{
    [JsonPropertyName("url")]
    public string Url { get; set; }
}
