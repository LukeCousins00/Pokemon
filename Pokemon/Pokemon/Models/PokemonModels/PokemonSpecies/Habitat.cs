using System.Text.Json.Serialization;

namespace Pokemon.Models.PokemonModels.PokemonSpecies.PokemonSpecies;

public class Habitat
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }
}
