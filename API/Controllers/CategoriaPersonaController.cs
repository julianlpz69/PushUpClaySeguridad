using API.Dtos;
using Applicacion.UnitOfWork;
using AutoMapper;
using API.Helpers;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CategoriaPersonaController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriaPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<CategoriaPersonaDto>>> Get([FromQuery]Params CategoriaPersonaParams)
        {
            var CategoriaPersona = await _unitOfWork.CategoriaPersonas.GetAllAsync(CategoriaPersonaParams.PageIndex, CategoriaPersonaParams.PageSize, CategoriaPersonaParams.Search, "NombreCategoria");
            var listaCategoriaPersona = _mapper.Map<List<CategoriaPersonaDto>>(CategoriaPersona.registros);
            return new Pager<CategoriaPersonaDto>(listaCategoriaPersona, CategoriaPersona.totalRegistros, CategoriaPersonaParams.PageIndex, CategoriaPersonaParams.PageSize, CategoriaPersonaParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaPersonaDto>> Get(int id)
        {
            var CategoriaPersona = await _unitOfWork.CategoriaPersonas.GetByIdAsync(id);
            return _mapper.Map<CategoriaPersonaDto>(CategoriaPersona);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaPersona>> Post(CategoriaPersonaDto CategoriaPersonaDto)
        {
            var CategoriaPersona = _mapper.Map<CategoriaPersona>(CategoriaPersonaDto);
            _unitOfWork.CategoriaPersonas.Add(CategoriaPersona);
            await _unitOfWork.SaveAsync();

            if (CategoriaPersona == null)
            {
                return BadRequest();
            }

            CategoriaPersona.Id = CategoriaPersona.Id;
            return CreatedAtAction(nameof(Post), new { id = CategoriaPersona.Id }, CategoriaPersona);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaPersonaDto>> Put(int id, [FromBody]CategoriaPersonaDto CategoriaPersonaDto)
        {
            if (CategoriaPersonaDto == null)
            {
                return NotFound();
            }

            var CategoriaPersona = _mapper.Map<CategoriaPersona>(CategoriaPersonaDto);
            _unitOfWork.CategoriaPersonas.Update(CategoriaPersona);
            await _unitOfWork.SaveAsync();
            return CategoriaPersonaDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaPersonaDto>> Delete(int id)
        {
            var CategoriaPersona = await _unitOfWork.CategoriaPersonas.GetByIdAsync(id);

            if (CategoriaPersona == null)
            {
                return NotFound();
            }

            _unitOfWork.CategoriaPersonas.Remove(CategoriaPersona);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }
}