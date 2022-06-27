using System.Text.Json.Serialization;

namespace Pokemon.Models.PokemonModels.PokemonSpecies.PokemonSpecies;

public class Genera
{
    [JsonPropertyName("genus")]
    public string Genus { get; set; }

    [JsonPropertyName("language")]
    public Language Language { get; set; }
}
