using Nómina.DTOs;
using Nómina.Models;
using Nómina.Repository;

namespace Nómina.Services
{
    public class EmpleadoService : IEmpleadoService
    {
        public readonly EmpleadoRepository _empleadoRepositoy;
        public EmpleadoService(EmpleadoRepository empleadoRepository)
        {
            _empleadoRepositoy = empleadoRepository;
        }
        public async Task<NominaDTO> GetNomina(int id)
        {
            var empleadoresult = await _empleadoRepositoy.GetByID(id);
            if(empleadoresult != null)
            {
                var nomina = new NominaDTO
                {
                    Nombre = empleadoresult.Nombre,
                    Cargo = empleadoresult.Cargo,
                    Salario_Base = empleadoresult.Salario_Base,
                    Bonificaciones = empleadoresult.Bonificaciones,
                    Deducciones = empleadoresult.Deducciones,
                    Nomina = CalcularNomina(empleadoresult.Salario_Base,empleadoresult.Deducciones,empleadoresult.Bonificaciones)
                };

                return nomina;
            }
            return null;
        }

        public async Task<IEnumerable<EmpleadoDTO>> Get()
        {
            var empleados = await _empleadoRepositoy.GetAll();
            return empleados.Select(e => new EmpleadoDTO()
            {
                ID = e.ID,
                Nombre = e.Nombre,
                Cargo = e.Cargo,
                Salario_Base = e.Salario_Base,
                Deducciones = e.Deducciones,
                Bonificaciones = e.Bonificaciones
            }).ToList();
            
        }
        public async Task<EmpleadoDTO> GetById(int id)
        {
            var empleado = await _empleadoRepositoy.GetByID(id);
            return new EmpleadoDTO()
            {
                ID = empleado.ID,
                Nombre = empleado.Nombre,
                Cargo = empleado.Cargo,
                Salario_Base = empleado.Salario_Base,
                Deducciones = empleado.Deducciones,
                Bonificaciones = empleado.Bonificaciones
            };
        }
        public async Task<EmpleadoDTO> Add(EmpleadoInsertDTO empleadoInsertDTO)
        {
            var empleado = new Empleados
            {
                Nombre = empleadoInsertDTO.Nombre,
                Cargo = empleadoInsertDTO.Cargo,
                Salario_Base = empleadoInsertDTO.Salario_Base,
                Deducciones = empleadoInsertDTO.Salario_Base * 0.10m,
                Bonificaciones = empleadoInsertDTO.Bonificaciones
            };
            await _empleadoRepositoy.Add(empleado);
            await _empleadoRepositoy.Save();
            
            return new EmpleadoDTO()
            {
                ID = empleado.ID,
                Nombre = empleado.Nombre,
                Cargo = empleado.Cargo,
                Salario_Base = empleado.Salario_Base,
                Deducciones = empleado.Deducciones,
                Bonificaciones = empleado.Bonificaciones
            };
        }
        public async Task<EmpleadoDTO> Update(EmpleadoUpdateDTO empleadoUpdateDTO, int id)
        {
            var empleado_result = await _empleadoRepositoy.GetByID(id);
            
            if(empleado_result != null)
            {
                empleado_result.Nombre = empleadoUpdateDTO.Nombre;
                empleado_result.Cargo = empleadoUpdateDTO.Cargo;
                empleado_result.Salario_Base = empleadoUpdateDTO.Salario_Base;
                empleado_result.Deducciones = empleadoUpdateDTO.Salario_Base * 0.10m;
                empleado_result.Bonificaciones = empleadoUpdateDTO.Bonificaciones;

                 _empleadoRepositoy.Update(empleado_result);
                await _empleadoRepositoy.Save();
                return new EmpleadoDTO()
                {
                    ID = empleado_result.ID,
                    Nombre = empleado_result.Nombre,
                    Cargo = empleado_result.Cargo,
                    Salario_Base = empleado_result.Salario_Base,
                    Deducciones = empleado_result.Deducciones,
                    Bonificaciones = empleado_result.Bonificaciones
                };
            }

            return null;
        }
        public async Task<EmpleadoDTO> Delete(int id)
        {
            var empleadoResult = await _empleadoRepositoy.GetByID(id);
            if (empleadoResult != null)
            {
                _empleadoRepositoy.Delete(empleadoResult);
                await _empleadoRepositoy.Save();
                return new EmpleadoDTO()
                {
                    ID = empleadoResult.ID,
                    Nombre = empleadoResult.Nombre,
                    Cargo = empleadoResult.Cargo,
                    Salario_Base = empleadoResult.Salario_Base,
                    Deducciones = empleadoResult.Deducciones,
                    Bonificaciones = empleadoResult.Bonificaciones
                };
            }
            else
            {
                return null;
            }
        }

        private decimal CalcularNomina(decimal salario,decimal deducciones ,decimal bonificacion)
        {
            return salario - deducciones + bonificacion;
        }
    }
}
