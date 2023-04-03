using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopApi.Dtos.PlanoDtos;
using PetShopApi.Models;
using PetShopApi.Persistence;

namespace PetShopApi.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class PlanoController : ControllerBase
    {
        public string url = Environment.GetEnvironmentVariable("ASPNETCORE_URLS").Split(";")[0];

        private PetShopContext _context;
        private IMapper _mapper;

        public PlanoController(IMapper mapper, PetShopContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreatePlanoDto planoDto)
        {
            Plano plano = _mapper.Map<Plano>(planoDto);
            _context.Planos.Add(plano);
            _context.SaveChanges();
            //return Created("http://localhost:5047/Plano/" + plano.PlanoId, plano);
            return CreatedAtAction(nameof(GetOne), new { id = plano.PlanoId }, plano);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Planos);
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            Plano? plano = _context.Planos.Where(plano => plano.PlanoId == id).Include(plano => plano.Animais).FirstOrDefault();
            if (plano == null)
            {
                return NotFound();
            }
            ReadPlanoDto planoDto = _mapper.Map<ReadPlanoDto>(plano);
            return Ok(planoDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdatePlanoDto planoDto)
        {
            Plano plano = _context.Planos.Find(id);
            if (plano == null)
            {
                return NotFound();
            }

            _mapper.Map(planoDto, plano);
            _context.Planos.Update(plano);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Plano plano = _context.Planos.Find(id);
            if (plano == null)
            {
                return NotFound();
            }
            _context.Planos.Remove(plano);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
