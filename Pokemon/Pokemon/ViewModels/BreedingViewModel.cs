namespace Pokemon.ViewModels;


public class BreedingViewModel
{
    public bool CanBreed { get; set; }
    public List<EggGroupViewModel> EggGroups { get; set; }
    public List<string> PokemonSprites { get; set; }
}

