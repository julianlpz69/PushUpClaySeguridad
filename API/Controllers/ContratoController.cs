using API.Dtos;
using Applicacion.UnitOfWork;
using AutoMapper;
using API.Helpers;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ContratoController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContratoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<ContratoDto>>> Get([FromQuery]Params ContratoParams)
        {
            var Contrato = await _unitOfWork.Contratos.GetAllAsync(ContratoParams.PageIndex, ContratoParams.PageSize, ContratoParams.Search, "Id");
            var listaContrato = _mapper.Map<List<ContratoDto>>(Contrato.registros);
            return new Pager<ContratoDto>(listaContrato, Contrato.totalRegistros, ContratoParams.PageIndex, ContratoParams.PageSize, ContratoParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContratoDto>> Get(int id)
        {
            var Contrato = await _unitOfWork.Contratos.GetByIdAsync(id);
            return _mapper.Map<ContratoDto>(Contrato);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Contrato>> Post(ContratoDto ContratoDto)
        {
            var Contrato = _mapper.Map<Contrato>(ContratoDto);
            _unitOfWork.Contratos.Add(Contrato);
            await _unitOfWork.SaveAsync();

            if (Contrato == null)
            {
                return BadRequest();
            }

            Contrato.Id = Contrato.Id;
            return CreatedAtAction(nameof(Post), new { id = Contrato.Id }, Contrato);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContratoDto>> Put(int id, [FromBody]ContratoDto ContratoDto)
        {
            if (ContratoDto == null)
            {
                return NotFound();
            }

            var Contrato = _mapper.Map<Contrato>(ContratoDto);
            _unitOfWork.Contratos.Update(Contrato);
            await _unitOfWork.SaveAsync();
            return ContratoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ContratoDto>> Delete(int id)
        {
            var Contrato = await _unitOfWork.Contratos.GetByIdAsync(id);

            if (Contrato == null)
            {
                return NotFound();
            }

            _unitOfWork.Contratos.Remove(Contrato);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }


         [HttpGet("activos")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         [ProducesResponseType(StatusCodes.Status400BadRequest)]
        
         public async Task<ActionResult<IEnumerable<ContratoActivosDto>>> Get()
         {
            var Contratos = await _unitOfWork.Contratos.ContratosActivos();
            return _mapper.Map<List<ContratoActivosDto>>(Contratos);
         }
    }
}