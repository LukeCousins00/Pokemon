using Microsoft.EntityFrameworkCore;
using Pokemon.Data;
using Pokemon.Data.Entities;
using Pokemon.Logic.Interfaces;

namespace Pokemon.Logic.Services;

public class PokemonService : IPokemonService
{
    private readonly ApplicationDbContext _db;

    public PokemonService(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<PokemonDetail>> GetPokemonDetailsAsync()
    {
        return await _db.PokemonDetails.ToListAsync();
    }

    public async Task<PokemonDetail?> GetPokemonDetailAsync(int id)
    {
        return await _db.PokemonDetails.FindAsync(id);
    }

    public async Task<PokemonDetail?> GetPokemonDetailAsync(string name)
    {
        return await _db.PokemonDetails.SingleOrDefaultAsync(p => p.Name == name);
    }

    public async Task<PokemonDetail> AddPokemonDetailAsync(PokemonDetail pokemonDetail)
    {
        await _db.PokemonDetails.AddAsync(pokemonDetail);
        await _db.SaveChangesAsync();

        return pokemonDetail;
    }
}