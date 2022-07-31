using Pokemon.Logic.Models.PokeApi.Sprite;

namespace Pokemon.ViewModels;


public class BreedingViewModel
{
    public bool CanBreed { get; set; }
    public List<EggGroupViewModel> EggGroups { get; set; }
    public List<Sprites> PokemonSprites { get; set; }
}

