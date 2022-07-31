using System.Text.Json.Serialization;

namespace Pokemon.Logic.Models.PokeApi.Sprite;

public class OfficialArtwork
{
    [JsonPropertyName("front_default")]
    public string FrontDefault { get; set; }
}