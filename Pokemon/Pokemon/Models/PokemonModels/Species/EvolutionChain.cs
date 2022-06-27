using System.Text.Json.Serialization;

namespace Pokemon.Models.PokemonModels.Species;

public class EvolutionChain
{
    [JsonPropertyName("url")]
    public string Url { get; set; }
}
