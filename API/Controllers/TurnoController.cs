using API.Dtos;
using Applicacion.UnitOfWork;
using AutoMapper;
using API.Helpers;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TurnoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TurnoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<TurnoDto>>> Get([FromQuery]Params TurnoParams)
        {
            var Turno = await _unitOfWork.Turnos.GetAllAsync(TurnoParams.PageIndex, TurnoParams.PageSize, TurnoParams.Search, "NombreTurno");
            var listaTurno = _mapper.Map<List<TurnoDto>>(Turno.registros);
            return new Pager<TurnoDto>(listaTurno, Turno.totalRegistros, TurnoParams.PageIndex, TurnoParams.PageSize, TurnoParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TurnoDto>> Get(int id)
        {
            var Turno = await _unitOfWork.Turnos.GetByIdAsync(id);
            return _mapper.Map<TurnoDto>(Turno);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Turno>> Post(TurnoDto TurnoDto)
        {
            var Turno = _mapper.Map<Turno>(TurnoDto);
            _unitOfWork.Turnos.Add(Turno);
            await _unitOfWork.SaveAsync();

            if (Turno == null)
            {
                return BadRequest();
            }

            Turno.Id = Turno.Id;
            return CreatedAtAction(nameof(Post), new { id = Turno.Id }, Turno);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TurnoDto>> Put(int id, [FromBody]TurnoDto TurnoDto)
        {
            if (TurnoDto == null)
            {
                return NotFound();
            }

            var Turno = _mapper.Map<Turno>(TurnoDto);
            _unitOfWork.Turnos.Update(Turno);
            await _unitOfWork.SaveAsync();
            return TurnoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TurnoDto>> Delete(int id)
        {
            var Turno = await _unitOfWork.Turnos.GetByIdAsync(id);

            if (Turno == null)
            {
                return NotFound();
            }

            _unitOfWork.Turnos.Remove(Turno);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}