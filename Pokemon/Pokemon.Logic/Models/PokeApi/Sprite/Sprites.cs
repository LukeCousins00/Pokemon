using System.Text.Json.Serialization;

namespace Pokemon.Logic.Models.PokeApi.Sprite;

public class Sprites
{
    [JsonPropertyName("other")]
    public Other Other { get; set; }

}
