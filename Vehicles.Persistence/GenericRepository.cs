using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles.Persistence
{
    public class GenericRepository<T> : RepositoryBase where T : class
    {
        public GenericRepository(IDbConnection connection) : base(connection) { }

        #region Synchronized

        public T this[int id]
        {
            get { return Get(id); }
            set { Update(value); }
        }

        public T Get(int id)
        {
            return this.Connection.Get<T>(id);
        }

        public IEnumerable<T> GetAll()
        {
            return this.Connection.GetAll<T>();
        }

        public bool Delete(T entity)
        {
            return this.Connection.Delete(entity);
        }

        public long Insert(T entity)
        {
            return this.Connection.Insert(entity);
        }

        public bool Update(T entity)
        {
            return this.Connection.Update(entity);
        }

        #endregion

        #region Async

        public Task<T> GetAsync(int id)
        {
            return this.Connection.GetAsync<T>(id);
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return this.Connection.GetAllAsync<T>();
        }

        public Task<bool> DeleteAsync(T entity)
        {
            return this.Connection.DeleteAsync(entity);
        }

        public Task<int> InsertAsync(T entity)
        {
            return this.Connection.InsertAsync(entity);
        }

        public Task<bool> UpdateAsync(T entity)
        {
            return this.Connection.UpdateAsync(entity);
        }

        #endregion
    }
}
