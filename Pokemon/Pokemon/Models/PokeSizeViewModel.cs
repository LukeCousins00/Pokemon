using System.Drawing;


namespace Pokemon.Models;

public class PokeSizeViewModel
{
    // View Model for the Size View on webpage
    public string PokemonName { get; set; }
    public int PokemonHeight { get; set; }
    public int PokemonWeight { get; set; }
    public string PokemonSpriteUrl { get; set; }
}
