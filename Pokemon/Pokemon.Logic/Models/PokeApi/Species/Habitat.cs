using System.Text.Json.Serialization;

namespace Pokemon.Logic.Models.PokeApi.Species;

public class Habitat
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}
