namespace Pokemon.ViewModels;

public class WhoViewModel
{
    public List<string> Choices { get; set; }   

    public int Seed { get; set; }

    public string SpriteUrl { get; set; }

    public bool? GuessedCorrectly { get; set; }

    public string SelectedPokemon { get; set; }

    public List<int> Generations { get; set; }

    public int AllTimeScore { get; set; }

    public int PersonalBest { get; set; }

    public int SessionScore { get; set; }
    // maybe the sound too :)
}
