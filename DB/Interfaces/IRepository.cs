namespace DB.Model.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IRepository<T> : IDisposable where T : class, IEntity
    {
        IQueryable<T> Query();
        IEnumerable<T> All();
        Task<IEnumerable<T>> AllAsync();
        T Get(Guid id);
        Task<T> GetAsync(Guid id);
        T Find(Func<T, bool> predicate);
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Attach(T entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
    }
}
