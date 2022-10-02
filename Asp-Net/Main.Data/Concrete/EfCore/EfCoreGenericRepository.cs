using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Data.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Main.Data.Concrete.EfCore
{
    public class EfCoreGenericRepository<TEtitiy> : IRepository<TEtitiy>
        where TEtitiy : class  // classdan yaranir
        // where TContext : DbContext, new()   // DbContextden yaranir ve newlene(yeni object yarana ) bilen
    {
        protected readonly DbContext db;
        public EfCoreGenericRepository(DbContext _db)
        {
            db = _db;
        }
        public void Create(TEtitiy entity)
        {
            db.Set<TEtitiy>().Add(entity);
            db.SaveChanges();
        }

        public async Task CreateAsync(TEtitiy entity)
        {
            await db.Set<TEtitiy>().AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public void Delete(TEtitiy entity)
        {
            db.Set<TEtitiy>().Remove(entity);
            db.SaveChanges();
        }

        public async Task<List<TEtitiy>> GetAll()
        {
            return await db.Set<TEtitiy>().ToListAsync();
        }

        public async Task<TEtitiy> GetById(int id)
        {
            return await db.Set<TEtitiy>().FindAsync(id);
        }

        public virtual void Update(TEtitiy entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}