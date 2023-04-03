using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopApi.Dtos.AnimalDtos;
using PetShopApi.Models;
using PetShopApi.Persistence;

namespace PetShopApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalController : ControllerBase
    {
        private PetShopContext _context;
        private IMapper _mapper;
        public AnimalController(PetShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateAnimalDto animalDto)   //Create([FromBody] Animal animal)
        {
            //Animal animal = new Animal()
            //{
            //    Nome = animalDto.Nome,
            //    Peso = animalDto.Peso,
            //    DataNascimento = animalDto.DataNascimento,
            //    Especie = animalDto.Especie,
            //    Castrado = animalDto.Castrado
            //};

            Animal animal = _mapper.Map<Animal>(animalDto);

            _context.Animais.Add(animal);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetOne), new { id = animal.AnimalId }, animal);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Animais);
        }

        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            Animal? animal = _context.Animais.Where(animal => animal.AnimalId == id).Include(animal => animal.Plano).FirstOrDefault();

            if (animal != null)
            {
                ReadAnimalDto animalDto = _mapper.Map<ReadAnimalDto>(animal);   
                animalDto.DataDaConsulta = DateTime.Now;

                return Ok(animalDto);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UpdateAnimalDto animalDto)
        {
            Animal animal = _context.Animais.Find(id);
            
            if(animal==null)
                return NotFound();

            //animal.Nome = animalDto.Nome;
            //animal.Peso = animalDto.Peso;
            //animal.DataNascimento = animalDto.DataNascimento;
            //animal.Especie = animalDto.Especie;
            //animal.Castrado = animalDto.Castrado;
            _mapper.Map(animalDto,animal);

            _context.Animais.Update(animal);
            _context.SaveChanges();
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Animal animal = _context.Animais.Find(id);
            if (animal == null)
                return NotFound();

            _context.Animais.Remove(animal);
            _context.SaveChanges();
            
            return NoContent();
        }
    }
}
