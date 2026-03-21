namespace CleanCity.Application.Core
{
    public abstract class BaseService<T> : IBaseService<T>
    {
        public abstract Task<ServiceResult> CreateAsync(T dto);
        public abstract Task<ServiceResult> UpdateAsync(T dto);
        public abstract Task<ServiceResult> DeleteAsync(int id);
        public abstract Task<T?> GetAsync(int id);
        public abstract Task<IEnumerable<T>> GetAllAsync();
    }
}