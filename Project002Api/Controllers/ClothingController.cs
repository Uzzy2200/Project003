using Microsoft.AspNetCore.Mvc;
using Project002Repository.Interfaces;
using Project002Repository.Models;
using Project002Repository.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project002Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothingController : ControllerBase
    {
        private readonly IClothingRepository _clothingRepo;

        public ClothingController(IClothingRepository clothingRepo)
        {
            _clothingRepo = clothingRepo;
        }


        // GET: api/<CountryController>
        [HttpGet]
        public IEnumerable<Clothes> GetAll()
        {
            var result = _clothingRepo.GetAll();
            return result;
        }
        [HttpPost]
        public void Create(Clothes clothes)
        {
            _clothingRepo.Create(clothes);
        }

        [HttpPut("{id}")]
        public ActionResult<Clothes> Update(int id, Clothes clothes)
        {
            if (id != clothes.ClothesId)
            {
                return BadRequest("ID in the request path does not match the ID in the provided entity.");
            }

            var existingClothing = _clothingRepo.GetById(id);
            if (existingClothing == null)
            {
                return NotFound();
            }

            // Ensure that the ID of the provided entity matches the ID in the request path
            clothes.ClothesId = id;

            _clothingRepo.Update(clothes);
            return Ok(clothes);
        }


        // DELETE api/<ClothingController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            // Retrieve the Samurai object from the database using the provided ID
            Clothes clothesToDelete = _clothingRepo.GetAll().FirstOrDefault(c => c.ClothesId == id);

            if (clothesToDelete == null)
            {
                // Return false or handle the case where the Samurai object with the provided ID doesn't exist
                return false;
            }

            // Call the Delete method in your repository to delete the Samurai object
            return _clothingRepo.Delete(clothesToDelete);
        }
        [HttpGet("{id}")]
        public ActionResult<Clothes> GetById(int id)
        {
            var clothes = _clothingRepo.GetById(id);
            if (clothes == null)
            {
                return NotFound();
            }
            return clothes;
        }
    }
}
