using System.Text.Json.Serialization;

namespace Pokemon.Models.PokemonModels;

public class PokemonSpecies
{
    [JsonPropertyName("base_happiness")]
    public int BaseHappiness { get; set; }

    [JsonPropertyName("capture_rate")]
    public int CaptureRate { get; set; }

    [JsonPropertyName("color")]
    public PokemonColor Color { get; set; }

    [JsonPropertyName("egg_groups")]
    public EggGroups[] EggGroups { get; set; }

    [JsonPropertyName("evolution_chain")]
    public EvolutionChain EvolutionChain { get; set; }

    [JsonPropertyName("evolves_from_species")]
    public EvolvesFromSpecies EvolvesFromSpecies { get; set; }

    [JsonPropertyName("flavor_text_entries")]
    public FlavorTextEntries[] FlavorTextEntries { get; set; }

    [JsonPropertyName("form_descriptions")]
    public object[] FormDescriptions { get; set; }

    [JsonPropertyName("forms_switchable")]
    public bool FormsSwitchable { get; set; }

    [JsonPropertyName("gender_rate")]
    public int GenderRate { get; set; }

    [JsonPropertyName("genera")]
    public Genera[] Genera { get; set; }

    [JsonPropertyName("generation")]
    public Generation Generation { get; set; }

    [JsonPropertyName("growth_rate")]
    public GrowthRate GrowthRate { get; set; }

    [JsonPropertyName("habitat")]
    public Habitat Habitat { get; set; }

    [JsonPropertyName("has_gender_differences")]
    public bool HasGenderDifferences { get; set; }

    [JsonPropertyName("hatch_counter")]
    public int HatchCounter { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("is_baby")]
    public bool IsBaby { get; set; }

    [JsonPropertyName("is_legendary")]
    public bool IsLegendary { get; set; }

    [JsonPropertyName("is_mythical")]
    public bool IsMythical { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("names")]
    public PokemonSpeciesName[] Names { get; set; }

    [JsonPropertyName("order")]
    public int Order { get; set; }

    [JsonPropertyName("pal_park_encounters")]
    public PalParkEncounters[] PalParkEncounters { get; set; }

    [JsonPropertyName("pokedex_numbers")]
    public PokedexNumbers[] PokedexNumbers { get; set; }

    [JsonPropertyName("shape")]
    public Shape Shape { get; set; }

    [JsonPropertyName("varieties")]
    public Variety[] Varieties { get; set; }
}
