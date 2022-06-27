using System.Text.Json.Serialization;

namespace Pokemon.Models.PokemonModels.Species;

public class PalParkEncounters
{
    [JsonPropertyName("area")]
    public PokemonArea Area { get; set; }

    [JsonPropertyName("base_score")]
    public int BaseScore { get; set; }

    [JsonPropertyName("rate")]
    public int Rate { get; set; }
}
