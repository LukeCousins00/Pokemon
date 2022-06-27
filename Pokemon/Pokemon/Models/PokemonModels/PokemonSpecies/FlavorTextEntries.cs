using System.Text.Json.Serialization;

namespace Pokemon.Models.PokemonModels.PokemonSpecies.PokemonSpecies;

public class FlavorTextEntries
{
    [JsonPropertyName("flavor_text")]
    public string FlavorText { get; set; }

    [JsonPropertyName("language")]
    public Language Language { get; set; }

    [JsonPropertyName("version")]
    public Version Version { get; set; }
}
