namespace DB.Model.DAL
{
    using DB.Model.Interfaces;
    using System.Data.Entity;
    using System.Threading.Tasks;

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dataContext = new TamgaContext();
        
        public IRepository<T> Repository<T>() where T : class, IEntity
        {
            return new Repository<T>(_dataContext);
        }

        public void Save()
        {
            _dataContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dataContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
