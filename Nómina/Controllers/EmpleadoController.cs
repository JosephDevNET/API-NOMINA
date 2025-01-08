using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nómina.DTOs;
using Nómina.Services;

namespace Nómina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;
        private readonly IValidator<EmpleadoInsertDTO> _ValidatorInsert;
        private readonly IValidator<EmpleadoUpdateDTO> _ValidatorUpdate;

        public EmpleadoController(IEmpleadoService empleadoService,IValidator<EmpleadoInsertDTO> validatorInsert,
            IValidator<EmpleadoUpdateDTO> ValidatorUpdate)
        {
            _empleadoService = empleadoService;
            _ValidatorInsert = validatorInsert;
            _ValidatorUpdate = ValidatorUpdate;
        }
        [HttpGet("{id}/calcular-nomina")]
        public async Task<ActionResult<NominaDTO>> GetNomina(int id)
        {
            return await _empleadoService.GetNomina(id);
        }

        [HttpGet]
        public async Task<IEnumerable<EmpleadoDTO>> Get()
        {
            return await _empleadoService.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmpleadoDTO>> GetById(int id)
        {
            var empleadoResult = await _empleadoService.GetById(id);
            return empleadoResult == null ? NotFound() : Ok(empleadoResult);
        }

        [HttpPost]
        public async Task<ActionResult<EmpleadoDTO>> Add(EmpleadoInsertDTO empleadoInsertDTO)
        {
            var result = _ValidatorInsert.Validate(empleadoInsertDTO);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            else
            {
                var empleadoResult = await _empleadoService.Add(empleadoInsertDTO);
                return CreatedAtAction(nameof(GetById), new { id = empleadoResult }, empleadoResult);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EmpleadoDTO>> Update(EmpleadoUpdateDTO empleadoUpdateDTO, int id)
        {
            var result = _ValidatorUpdate.Validate(empleadoUpdateDTO);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            else
            {
                var empleadoResult = await _empleadoService.Update(empleadoUpdateDTO, id);
                return CreatedAtAction(nameof(GetById), new { id = empleadoResult }, empleadoResult);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EmpleadoDTO>> Delete(int id)
        {
            var empleadoResult = await _empleadoService.Delete(id);
            return empleadoResult == null ? NotFound() : Ok(empleadoResult);
        }
    }
}
