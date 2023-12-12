using API.Dtos;
using Applicacion.UnitOfWork;
using AutoMapper;
using API.Helpers;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProgramacionController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProgramacionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<ProgramacionDto>>> Get([FromQuery]Params ProgramacionParams)
        {
            var Programacion = await _unitOfWork.Programaciones.GetAllAsync(ProgramacionParams.PageIndex, ProgramacionParams.PageSize, ProgramacionParams.Search, "Id");
            var listaProgramacion = _mapper.Map<List<ProgramacionDto>>(Programacion.registros);
            return new Pager<ProgramacionDto>(listaProgramacion, Programacion.totalRegistros, ProgramacionParams.PageIndex, ProgramacionParams.PageSize, ProgramacionParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProgramacionDto>> Get(int id)
        {
            var Programacion = await _unitOfWork.Programaciones.GetByIdAsync(id);
            return _mapper.Map<ProgramacionDto>(Programacion);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Programacion>> Post(ProgramacionDto ProgramacionDto)
        {
            var Programacion = _mapper.Map<Programacion>(ProgramacionDto);
            _unitOfWork.Programaciones.Add(Programacion);
            await _unitOfWork.SaveAsync();

            if (Programacion == null)
            {
                return BadRequest();
            }

            Programacion.Id = Programacion.Id;
            return CreatedAtAction(nameof(Post), new { id = Programacion.Id }, Programacion);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProgramacionDto>> Put(int id, [FromBody]ProgramacionDto ProgramacionDto)
        {
            if (ProgramacionDto == null)
            {
                return NotFound();
            }

            var Programacion = _mapper.Map<Programacion>(ProgramacionDto);
            _unitOfWork.Programaciones.Update(Programacion);
            await _unitOfWork.SaveAsync();
            return ProgramacionDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProgramacionDto>> Delete(int id)
        {
            var Programacion = await _unitOfWork.Programaciones.GetByIdAsync(id);

            if (Programacion == null)
            {
                return NotFound();
            }

            _unitOfWork.Programaciones.Remove(Programacion);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}