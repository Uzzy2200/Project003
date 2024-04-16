using Microsoft.AspNetCore.Mvc;
using Project002Repository.Interfaces;
using Project002Repository.Repositories;
using Project002Repository.Models;
using Project002.Repository.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project002Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarController : ControllerBase
    {
        private readonly IWarRepository _warRepo;

        public WarController(IWarRepository warRepo)
        {
            _warRepo = warRepo;
        }


        // GET: api/<WarController>
        [HttpGet]
        public IEnumerable<War> GetAll()
        {
            var result = _warRepo.GetAll();
            return result;
        }

        //CREATE
        [HttpPost]
        public void Create(War war)
        {
            _warRepo.Create(war);
        }

        // DELETE api/<SamuraiController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            // Retrieve the Samurai object from the database using the provided ID
            War warToDelete = _warRepo.GetAll().FirstOrDefault(c => c.WarId == id);

            if (warToDelete == null)
            {
                // Return false or handle the case where the Samurai object with the provided ID doesn't exist
                return false;
            }

            // Call the Delete method in your repository to delete the Samurai object
            return _warRepo.Delete(warToDelete);
        }
        [HttpPut("{id}")]
        public ActionResult<War> Update(int id, War war)
        {
            if (id != war.WarId)
            {
                return BadRequest("ID in the request path does not match the ID in the provided entity.");
            }

            var existingWar = _warRepo.GetById(id);
            if (existingWar == null)
            {
                return NotFound();
            }

            // Ensure that the ID of the provided entity matches the ID in the request path
            war.WarId = id;

            _warRepo.Update(war);
            return Ok(war);
        }


        [HttpGet("{id}")]
        public ActionResult<War> GetById(int id)
        {
            var war = _warRepo.GetById(id);
            if (war == null)
            {
                return NotFound();
            }
            return war;
        }

    }
}
