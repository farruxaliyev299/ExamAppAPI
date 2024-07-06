using ExamApp.Abstraction;
using ExamApp.DAL;
using ExamApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamApp.Concrete;

public class DersService : IDersService
{
    ExamAppDbContext _dbContext;

    public DersService(ExamAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<Ders>> FetchAllAsync()
    {
        return _dbContext.Ders.AsNoTracking().ToListAsync();
    }

    public async Task<Ders> FetchAsync(string kod)
    {
        var obj = await _dbContext.Ders.AsNoTracking().FirstOrDefaultAsync(d => d.Kod == kod);

        return obj;
    }

    public async Task<int> CreateAsync(Ders ders)
    {
        await _dbContext.Ders.AddAsync(ders);

        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(Ders ders)
    {
        _dbContext.Ders.Update(ders);

        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(Ders ders)
    {
        _dbContext.Ders.Remove(ders);

        return await _dbContext.SaveChangesAsync();
    }
}
