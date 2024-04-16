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
    public class ClanController : ControllerBase
    {

            private readonly IClanRepository _clanRepo;

            public ClanController(IClanRepository clanRepo)
            {
                _clanRepo = clanRepo;
            }

            // GET: api/<CountryController>
            [HttpGet]
        public IEnumerable<Clan> GetAll()
        {
            var result = _clanRepo.GetAll();
            return result;
        }
        [HttpPost]
        public void Create(Clan clan)
        {
            _clanRepo.Create(clan);
        }

  

        // DELETE api/<SamuraiController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            // Retrieve the Samurai object from the database using the provided ID
            Clan clanToDelete = _clanRepo.GetAll().FirstOrDefault(c => c.ClanId == id);

            if (clanToDelete == null)
            {
                // Return false or handle the case where the Samurai object with the provided ID doesn't exist
                return false;
            }

            // Call the Delete method in your repository to delete the Samurai object
            return _clanRepo.Delete(clanToDelete);
        }
        [HttpPut("{id}")]
        public ActionResult<Clan> Update(int id, Clan clan)
        {
            if (id != clan.ClanId)
            {
                return BadRequest("ID in the request path does not match the ID in the provided entity.");
            }

            var existingClan = _clanRepo.GetById(id);
            if (existingClan == null)
            {
                return NotFound();
            }

            // Ensure that the ID of the provided entity matches the ID in the request path
            clan.ClanId = id;

            _clanRepo.Update(clan);
            return Ok(clan);
        }


        [HttpGet("{id}")]
        public ActionResult<Clan> GetById(int id)
        {
            var clan = _clanRepo.GetById(id);
            if (clan == null)
            {
                return NotFound();
            }
            return clan;
        }

    }
}
