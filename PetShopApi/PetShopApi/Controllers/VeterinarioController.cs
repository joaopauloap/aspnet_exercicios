using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopApi.Dtos.VeterinarioDtos;
using PetShopApi.Models;
using PetShopApi.Persistence;

namespace PetShopApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VeterinarioController : ControllerBase
    {
        private PetShopContext _context;
        private IMapper _mapper;

        public VeterinarioController(PetShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Veterinarios.Include(v=>v.ContratoTrabalho));
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            //Veterinario veterinario = _context.Veterinarios.Find(id);
            Veterinario veterinario = _context.Veterinarios.Include(v => v.ContratoTrabalho).Where(v=>v.VeterinarioId == id).FirstOrDefault();
            if(veterinario == null)
                return NotFound();

            ReadVeterinarioDto veterinarioDto = _mapper.Map<ReadVeterinarioDto>(veterinario);
            return Ok(veterinarioDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateVeterinarioDto veterinarioDto) //Dtos servem para quando há uma transferencia (enviou ou recebimento) com usuario de dados pelo body da requisição
        {
            Veterinario veterinario = _mapper.Map<Veterinario>(veterinarioDto); 
            _context.Veterinarios.Add(veterinario);
            _context.SaveChanges();

            // return Created("localhost:5047/Veterinario/"+veterinario.VeterinarioId,veterinario);
            return CreatedAtAction(nameof(GetOne), new { Id = veterinario.VeterinarioId }, veterinario);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateVeterinarioDto veterinarioDto)
        {
            Veterinario veterinario = _context.Veterinarios.Find(id);
            if(veterinario == null) return NotFound();

            _mapper.Map(veterinarioDto, veterinario);
            _context.Veterinarios.Update(veterinario);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Veterinario? veterinario = _context.Veterinarios.Find(id);
            if (veterinario == null) return NotFound();
            
            _context.Veterinarios.Remove(veterinario);
            _context.SaveChanges();
            
            return NoContent();
        }
    }
}
