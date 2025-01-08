using Microsoft.EntityFrameworkCore;
using Nómina.Models;

namespace Nómina.Repository
{
    public class EmpleadoRepository : IRepository<Empleados>
    {
        private DatabaseContext _databaseContext;
        public EmpleadoRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<IEnumerable<Empleados>> GetAll() => await _databaseContext.Empleados.ToListAsync();
        public async Task<Empleados> GetByID(int id) => await _databaseContext.Empleados.FirstOrDefaultAsync(x => x.ID == id);
        public async Task Add(Empleados entity)
        {
            await _databaseContext.Empleados.AddAsync(entity);
        }
        public void Update(Empleados entity)
        {
            _databaseContext.Empleados.Attach(entity);
            _databaseContext.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(Empleados entity)
        {
            _databaseContext.Empleados.Remove(entity);
        }
        public async Task Save()
        {
            await _databaseContext.SaveChangesAsync();
        }
    }
}
