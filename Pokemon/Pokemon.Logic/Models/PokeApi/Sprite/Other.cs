using System.Text.Json.Serialization;

namespace Pokemon.Logic.Models.PokeApi.Sprite;

public class Other
{
    [JsonPropertyName("official-artwork")]
    public OfficialArtwork OfficialArtwork { get; set; }
}