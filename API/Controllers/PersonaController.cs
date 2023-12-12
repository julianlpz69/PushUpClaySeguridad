using API.Dtos;
using Applicacion.UnitOfWork;
using AutoMapper;
using API.Helpers;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PersonaController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<PersonaDto>>> Get([FromQuery]Params PersonaParams)
        {
            var Persona = await _unitOfWork.Personas.GetAllAsync(PersonaParams.PageIndex, PersonaParams.PageSize, PersonaParams.Search, "IdPersona");
            var listaPersona = _mapper.Map<List<PersonaDto>>(Persona.registros);
            return new Pager<PersonaDto>(listaPersona, Persona.totalRegistros, PersonaParams.PageIndex, PersonaParams.PageSize, PersonaParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaDto>> Get(int id)
        {
            var Persona = await _unitOfWork.Personas.GetByIdAsync(id);
            return _mapper.Map<PersonaDto>(Persona);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Persona>> Post(PersonaDto PersonaDto)
        {
            var Persona = _mapper.Map<Persona>(PersonaDto);
            _unitOfWork.Personas.Add(Persona);
            await _unitOfWork.SaveAsync();

            if (Persona == null)
            {
                return BadRequest();
            }

            Persona.Id = Persona.Id;
            return CreatedAtAction(nameof(Post), new { id = Persona.Id }, Persona);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaDto>> Put(int id, [FromBody]PersonaDto PersonaDto)
        {
            if (PersonaDto == null)
            {
                return NotFound();
            }

            var Persona = _mapper.Map<Persona>(PersonaDto);
            _unitOfWork.Personas.Update(Persona);
            await _unitOfWork.SaveAsync();
            return PersonaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PersonaDto>> Delete(int id)
        {
            var Persona = await _unitOfWork.Personas.GetByIdAsync(id);

            if (Persona == null)
            {
                return NotFound();
            }

            _unitOfWork.Personas.Remove(Persona);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }






         [HttpGet("empleados")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<IEnumerable<PersonaDto>>> Get()
         {
            var Personas = await _unitOfWork.Personas.Empleados();
            return _mapper.Map<List<PersonaDto>>(Personas);
         }



         [HttpGet("empleadosVigilantes")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<IEnumerable<PersonaDto>>> Get2()
         {
            var Personas = await _unitOfWork.Personas.EmpleadosVigilantes();
            return _mapper.Map<List<PersonaDto>>(Personas);
         }



         [HttpGet("clientesbga")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<IEnumerable<PersonaDto>>> Get3()
         {
            var Personas = await _unitOfWork.Personas.ClientesBGA();
            return _mapper.Map<List<PersonaDto>>(Personas);
         }


         [HttpGet("EmpleadosGP")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<IEnumerable<PersonaDto>>> Get4()
         {
            var Personas = await _unitOfWork.Personas.EmpleadosGP();
            return _mapper.Map<List<PersonaDto>>(Personas);
         }


         [HttpGet("Clientes5Years")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<IEnumerable<PersonaDto>>> Get5()
         {
            var Personas = await _unitOfWork.Personas.Clientes5Years();
            return _mapper.Map<List<PersonaDto>>(Personas);
         }
    }
}