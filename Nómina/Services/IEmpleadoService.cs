using Nómina.DTOs;

namespace Nómina.Services
{
    public interface IEmpleadoService
    {
        Task<NominaDTO> GetNomina(int id);
        Task<IEnumerable<EmpleadoDTO>> Get();
        Task<EmpleadoDTO> GetById(int id);
        Task<EmpleadoDTO> Add(EmpleadoInsertDTO insertDTO);
        Task<EmpleadoDTO> Update(EmpleadoUpdateDTO empleadoUpdateDTO, int id);
        Task<EmpleadoDTO> Delete(int id);
    }
}
