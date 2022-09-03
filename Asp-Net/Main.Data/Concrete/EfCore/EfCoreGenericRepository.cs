using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Data.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Main.Data.Concrete.EfCore
{
    public class EfCoreGenericRepository<TEtitiy, TContext> : IRepository<TEtitiy>
        where TEtitiy : class  // classdan yaranir
        where TContext : DbContext, new()   // DbContextden yaranir ve newlene(yeni object yarana ) bilen
    {
        public void Create(TEtitiy entity)
        {
            using( var db = new TContext() )
            {
                db.Set<TEtitiy>().Add(entity);
                db.SaveChanges();
            }
        }

        public void Delete(TEtitiy entity)
        {
            using( var db = new TContext() )
            {
                db.Set<TEtitiy>().Remove(entity);
                db.SaveChanges();
            }
        }

        public List<TEtitiy> GetAll()
        {
            using( var db = new TContext() )
            {
                return db.Set<TEtitiy>().ToList();
            }
        }

        public TEtitiy GetById(int id)
        {
            using( var db = new TContext() )
            {
                return db.Set<TEtitiy>().Find(id);
            }
        }

        public void Update(TEtitiy entity)
        {
            using( var db = new TContext())
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}