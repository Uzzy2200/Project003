using Microsoft.AspNetCore.Mvc;
using Project002.Repository.Models;
using Project002Repository.Interfaces;
using Project002Repository.Models;
using Project002Repository.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project002Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorsesController : ControllerBase
    {
        private readonly IHorseRepository _horseRepo;

        public HorsesController(IHorseRepository horseRepo)
        {
            _horseRepo = horseRepo;
        }

        // GET: api/<HorsesController>
        [HttpGet]
        public IEnumerable<Horses> GetAll()
        {
            var result = _horseRepo.GetAll();
            return result;
        }
        //CREATE
        [HttpPost]
        public void Create(Horses horses)
        {
            _horseRepo.Create(horses);
        }



        [HttpPut("{id}")]
        public ActionResult<Horses> Update(int id, Horses horses)
        {
            if (id != horses.HorseId)
            {
                return BadRequest("ID in the request path does not match the ID in the provided entity.");
            }

            var existingHorse = _horseRepo.GetById(id);
            if (existingHorse == null)
            {
                return NotFound();
            }

            // Ensure that the ID of the provided entity matches the ID in the request path
            horses.HorseId = id;

            _horseRepo.Update(horses);
            return Ok(horses);
        }


        // DELETE api/<HorsesController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            // Retrieve the Samurai object from the database using the provided ID
            Horses horseToDelete = _horseRepo.GetAll().FirstOrDefault(h => h.HorseId == id);

            if (horseToDelete == null)
            {
                // Return false or handle the case where the Samurai object with the provided ID doesn't exist
                return false;
            }

            // Call the Delete method in your repository to delete the Samurai object
            return _horseRepo.Delete(horseToDelete);
        }
        [HttpGet("{id}")]
        public ActionResult<Horses> GetById(int id)
        {
            var horses = _horseRepo.GetById(id);
            if (horses == null)
            {
                return NotFound();
            }
            return horses;
        }
    }
}
