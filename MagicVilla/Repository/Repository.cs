using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI.Repository{
    public class Repository<T>:IRepository<T> where T:class
    {
        private readonly ApplicationDBContext _db;
        internal DbSet<T>dbSet;
        public Repository(ApplicationDBContext db){
            _db=db;
            this.dbSet=_db.Set<T>();
        }
      public async Task Create(T entity){
        // throw new NotImplementedException();
       await dbSet.AddAsync(entity);
        await Save();
      }
        public async  Task<T> Get(Expression<Func<T, bool>> filter = null, bool tracked = true)
        {
            IQueryable<T > query=dbSet;
        if(!tracked){
          query=query.AsNoTracking();
        }
        
        if(filter!=null){
          query=query.Where(filter);
        }
        return  await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T > query=dbSet;
        if(filter!=null){
          query=query.Where(filter);
        }
        return await query.ToListAsync();
        }

        public async Task Remove(T entity)
        {
             dbSet.Remove(entity);
              await Save();
        }

        public async Task Save()
        {
             await _db.SaveChangesAsync();
        }

        // public async  Task Update(T entity)
        // {
        //     _db.Villas.Update(entity);
        //       await Save();
        // }
    }
}