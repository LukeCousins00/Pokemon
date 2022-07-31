using System.Text.Json.Serialization;

namespace Pokemon.Logic.Models.PokeApi.Generation;

public class PokemonGeneration
{
    [JsonPropertyName("pokemon_species")]
    public List<GenerationSpecies> Species { get; set; }    
}
