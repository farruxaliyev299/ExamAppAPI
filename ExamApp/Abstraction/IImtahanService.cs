using ExamApp.Entities;

namespace ExamApp.Abstraction;

public interface IImtahanService
{
    Task<List<Imtahan>> FetchAllAsync();

    Task<Imtahan> FetchAsync(decimal nomre);

    Task<int> CreateAsync(Imtahan ders);

    Task<int> UpdateAsync(Imtahan ders);

    Task<int> DeleteAsync(Imtahan ders);
}
