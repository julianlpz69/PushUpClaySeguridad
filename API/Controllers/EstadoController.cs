using API.Dtos;
using Applicacion.UnitOfWork;
using AutoMapper;
using API.Helpers;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EstadoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EstadoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<EstadoDto>>> Get([FromQuery]Params EstadoParams)
        {
            var Estado = await _unitOfWork.Estados.GetAllAsync(EstadoParams.PageIndex, EstadoParams.PageSize, EstadoParams.Search, "Descripcion");
            var listaEstado = _mapper.Map<List<EstadoDto>>(Estado.registros);
            return new Pager<EstadoDto>(listaEstado, Estado.totalRegistros, EstadoParams.PageIndex, EstadoParams.PageSize, EstadoParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EstadoDto>> Get(int id)
        {
            var Estado = await _unitOfWork.Estados.GetByIdAsync(id);
            return _mapper.Map<EstadoDto>(Estado);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Estado>> Post(EstadoDto EstadoDto)
        {
            var Estado = _mapper.Map<Estado>(EstadoDto);
            _unitOfWork.Estados.Add(Estado);
            await _unitOfWork.SaveAsync();

            if (Estado == null)
            {
                return BadRequest();
            }

            Estado.Id = Estado.Id;
            return CreatedAtAction(nameof(Post), new { id = Estado.Id }, Estado);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EstadoDto>> Put(int id, [FromBody]EstadoDto EstadoDto)
        {
            if (EstadoDto == null)
            {
                return NotFound();
            }

            var Estado = _mapper.Map<Estado>(EstadoDto);
            _unitOfWork.Estados.Update(Estado);
            await _unitOfWork.SaveAsync();
            return EstadoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EstadoDto>> Delete(int id)
        {
            var Estado = await _unitOfWork.Estados.GetByIdAsync(id);

            if (Estado == null)
            {
                return NotFound();
            }

            _unitOfWork.Estados.Remove(Estado);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}