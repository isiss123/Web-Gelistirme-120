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

        public void Delete(TEtitiy entity)
        {
            db.Set<TEtitiy>().Remove(entity);
            db.SaveChanges();
        }

        public List<TEtitiy> GetAll()
        {
            return db.Set<TEtitiy>().ToList();
        }

        public TEtitiy GetById(int id)
        {
            return db.Set<TEtitiy>().Find(id);
        }

        public virtual void Update(TEtitiy entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}