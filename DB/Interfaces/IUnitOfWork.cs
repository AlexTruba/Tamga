namespace DB.Model.Interfaces
{
    using System;
    using System.Threading.Tasks;
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class, IEntity;
        void Save();
        Task SaveAsync();
    }
}
