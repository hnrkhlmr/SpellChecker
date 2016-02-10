using SpellChecker.Dal.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;

namespace SpellChecker.Dal
{
    public class EntityRepository : IEntityRepository<Word>
    {
        protected SpellCheckerContext _context;

        public EntityRepository()
        {
            _context = new SpellCheckerContext();
        }

        public EntityRepository(SpellCheckerContext context)
        {
            _context = context;
        }
        

        public IQueryable<Word> All
        {
            get { return _context.Words; }
        }

        public IQueryable<Word> AllIncluding(params System.Linq.Expressions.Expression<Func<Word, object>>[] includeProperties)
        {
            IQueryable<Word> query = _context.Words;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Word Find(int id)
        {
            return _context.Words.Find(id);
        }

        public void InsertOrUpdate(Word entity)
        {
            if (entity.WordId.Equals(0))
            {
                // New entity                
                _context.Words.Add(entity);
            }
            else
            {
                // Existing entity
                _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            }
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = Find(id);
            _context.Words.Remove(entity);

            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
