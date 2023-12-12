using API.Dtos;
using Applicacion.UnitOfWork;
using AutoMapper;
using API.Helpers;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TipoPersonaController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TipoPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<TipoPersonaDto>>> Get([FromQuery]Params TipoPersonaParams)
        {
            var TipoPersona = await _unitOfWork.TipoPersonas.GetAllAsync(TipoPersonaParams.PageIndex, TipoPersonaParams.PageSize, TipoPersonaParams.Search, "Descripcion");
            var listaTipoPersona = _mapper.Map<List<TipoPersonaDto>>(TipoPersona.registros);
            return new Pager<TipoPersonaDto>(listaTipoPersona, TipoPersona.totalRegistros, TipoPersonaParams.PageIndex, TipoPersonaParams.PageSize, TipoPersonaParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoPersonaDto>> Get(int id)
        {
            var TipoPersona = await _unitOfWork.TipoPersonas.GetByIdAsync(id);
            return _mapper.Map<TipoPersonaDto>(TipoPersona);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoPersona>> Post(TipoPersonaDto TipoPersonaDto)
        {
            var TipoPersona = _mapper.Map<TipoPersona>(TipoPersonaDto);
            _unitOfWork.TipoPersonas.Add(TipoPersona);
            await _unitOfWork.SaveAsync();

            if (TipoPersona == null)
            {
                return BadRequest();
            }

            TipoPersona.Id = TipoPersona.Id;
            return CreatedAtAction(nameof(Post), new { id = TipoPersona.Id }, TipoPersona);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoPersonaDto>> Put(int id, [FromBody]TipoPersonaDto TipoPersonaDto)
        {
            if (TipoPersonaDto == null)
            {
                return NotFound();
            }

            var TipoPersona = _mapper.Map<TipoPersona>(TipoPersonaDto);
            _unitOfWork.TipoPersonas.Update(TipoPersona);
            await _unitOfWork.SaveAsync();
            return TipoPersonaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TipoPersonaDto>> Delete(int id)
        {
            var TipoPersona = await _unitOfWork.TipoPersonas.GetByIdAsync(id);

            if (TipoPersona == null)
            {
                return NotFound();
            }

            _unitOfWork.TipoPersonas.Remove(TipoPersona);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}