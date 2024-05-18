using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SocialNet.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbContext _db;

        public DbSet<T> Set { get; private set; }

        public Repository(ApplicationDbContext db)
        
        {
            _db = db;
            var set =_db.Set<T>();
            set.Load();

            Set = set;
        }

        // public async Task<int> Create(T item)
        // {
        //     Set.Add(item);
        //     return await _db.SaveChangesAsync();
        // }
        //
        // public async Task<int> Delete(T item)
        // {
        //     Set.Remove(item);
        //     return await _db.SaveChangesAsync();
        // }
        //
        // public async Task<T> Get(int id)
        // {
        //     return await Set.FindAsync(id);
        // }
        //
        // public IEnumerable<T> GetAll()
        // {
        //     return Set;
        // }
        //
        // public async Task<int> Update(T item)
        // {
        //     Set.Update(item);
        //     return await _db.SaveChangesAsync();
        // }
        public void Create(T item)
        {
            Set.Add(item);
            _db.SaveChanges();
        }

        public void Delete(T item)
        {
            Set.Remove(item);
            _db.SaveChanges();
        }

        public T Get(int id)
        {
            return Set.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return Set;
        }

        public void Update(T item)
        {
            Set.Update(item);
            _db.SaveChanges();
        }
    }
}