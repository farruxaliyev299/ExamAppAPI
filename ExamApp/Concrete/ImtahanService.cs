using ExamApp.Abstraction;
using ExamApp.DAL;
using ExamApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamApp.Concrete;

public class ImtahanService : IImtahanService
{
    ExamAppDbContext _dbContext;

    public ImtahanService(ExamAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<Imtahan>> FetchAllAsync()
    {
        return _dbContext.Imtahan.AsNoTracking().ToListAsync();
    }

    public async Task<Imtahan> FetchAsync(decimal nomre)
    {
        var obj = await _dbContext.Imtahan.AsNoTracking().FirstOrDefaultAsync(d => d.Nomre == nomre);

        return obj;
    }

    public async Task<int> CreateAsync(Imtahan ders)
    {
        await _dbContext.Imtahan.AddAsync(ders);

        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(Imtahan ders)
    {
        _dbContext.Imtahan.Update(ders);

        return await _dbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(Imtahan ders)
    {
        _dbContext.Imtahan.Remove(ders);

        return await _dbContext.SaveChangesAsync();
    }
}
