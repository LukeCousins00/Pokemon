using Microsoft.EntityFrameworkCore;
using Pokemon.Data.Entities;

namespace Pokemon.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<PokemonDetail> PokemonDetails { get; set; }
}