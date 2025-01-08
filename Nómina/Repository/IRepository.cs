namespace Nómina.Repository
{
    public interface IRepository<IEntity>
    {
        Task<IEnumerable<IEntity>> GetAll();
        Task<IEntity> GetByID(int id);
        Task Add(IEntity entity);
        void Update(IEntity entity);
        void Delete(IEntity entity);
        Task Save();

    }
}
