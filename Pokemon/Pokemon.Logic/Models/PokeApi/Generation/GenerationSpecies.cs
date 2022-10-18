using System.Text.Json.Serialization;

namespace Pokemon.Logic.Models.PokeApi.Generation;

public class GenerationSpecies
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
}
