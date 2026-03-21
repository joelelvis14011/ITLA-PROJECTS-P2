namespace CleanCity.Application.Core
{
    public interface IBaseService<T>
    {
        Task<ServiceResult> CreateAsync(T dto);
        Task<ServiceResult> UpdateAsync(T dto);
        Task<ServiceResult> DeleteAsync(int id);
        Task<T?> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}