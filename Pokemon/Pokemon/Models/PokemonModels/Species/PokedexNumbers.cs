using System.Text.Json.Serialization;

namespace Pokemon.Models.PokemonModels.Species;

public class PokedexNumbers
{
    [JsonPropertyName("entry_number")]
    public int EntryNumber { get; set; }

    [JsonPropertyName("pokedex")]
    public Pokedex Pokedex { get; set; }
}
