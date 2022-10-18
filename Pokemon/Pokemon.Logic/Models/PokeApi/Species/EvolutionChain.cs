using System.Text.Json.Serialization;

namespace Pokemon.Logic.Models.PokeApi.Species;

public class EvolutionChain
{
    [JsonPropertyName("url")]
    public string Url { get; set; }
}
