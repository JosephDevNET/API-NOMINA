using FluentValidation;
using Nómina.DTOs;

namespace Nómina.Validation
{
    public class EmpleadoInsertValidation: AbstractValidator<EmpleadoInsertDTO> 
    {
        public EmpleadoInsertValidation()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre es obligatorio crack");
            RuleFor(x => x.Salario_Base).GreaterThan(1000).WithMessage("El salario no puede ser menor de 1000");
        }
    }
}
