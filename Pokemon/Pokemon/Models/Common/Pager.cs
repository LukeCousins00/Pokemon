namespace Pokemon.Models.Common;

public class Pager
{
    public int Count { get; set; }
    public int PageSize { get; set; }
    public int MaxPages { get; set; } = 5;
    public string Action { get; set; }
    public string Controller { get; set; }
}
