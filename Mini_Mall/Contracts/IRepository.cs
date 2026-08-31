namespace Mini_Mall.Contracts
{
    public interface IRepository<T> where T: class
    {
        Task<bool> Add(T item);
        Task<bool> Update(T item);
        Task<bool> Remove(int id);
        Task<T> GetByid(int id);
    }
}
