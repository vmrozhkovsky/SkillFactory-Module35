using Microsoft.AspNetCore.Mvc;

namespace SocialNet.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        // IEnumerable<T> GetAll();
        // Task<T> Get(int id);
        // Task<int> Create(T item);
        // Task<int> Update(T item);
        // Task<int> Delete(T item);
        IEnumerable<T> GetAll();
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
    }
}