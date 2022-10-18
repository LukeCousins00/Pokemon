using System.Text.Json.Serialization;

namespace Pokemon.Logic.Models.PokeApi.Species;

public class Genera
{
    [JsonPropertyName("genus")]
    public string Genus { get; set; }

    [JsonPropertyName("language")]
    public Language Language { get; set; }
}
