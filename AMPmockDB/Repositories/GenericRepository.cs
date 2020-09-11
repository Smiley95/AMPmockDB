using AMPmockDB.DBContext;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AMPmockDB.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private APMDBEntities _context;  
        private DbSet<T> _dbSet;
        
        public GenericRepository()
        {
            _context = new APMDBEntities();
            _dbSet = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public T Insert(T obj)
        {
            _dbSet.Add(obj);
            Save();
            return obj;
        }

        public T Update(T obj)
        {
            _dbSet.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            Save();
            return obj;
        }

        public void Delete(object id)
        {
            T existing = _dbSet.Find(id);
            if(existing == null)
            {
                throw new Exception("object not existing!");
            }
            _dbSet.Remove(existing);
            Save();
        }

        public void Save()
        {
            
            
            _context.SaveChanges();
        }
        public void Dispose(){  
            if (_context != null) {  
                _context.Dispose();  
                _context = null;  
            }
        }    
    }
}