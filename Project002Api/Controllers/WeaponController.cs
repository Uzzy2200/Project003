using Microsoft.AspNetCore.Mvc;
using Project002Repository.Interfaces;
using Project002Repository.Models;
using Project002Repository.Repositories;
using Project002.Repository.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project002Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {

        private readonly IWeaponRepository _weaponRepo;

        public WeaponController(IWeaponRepository weaponRepo)
        {
            _weaponRepo = weaponRepo;
        }

        // GET: api/<WeaponController>
        [HttpGet]
        public IEnumerable<Weapon> GetAll()
        {
            var result = _weaponRepo.GetAll();
            return result;
        }
        [HttpPost]
        public void Create(Weapon weapon)
        {
            _weaponRepo.Create(weapon);
        }

        // DELETE api/<SamuraiController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            // Retrieve the Samurai object from the database using the provided ID
            Weapon weaponToDelete = _weaponRepo.GetAll().FirstOrDefault(c => c.WeaponId == id);

            if (weaponToDelete == null)
            {
                // Return false or handle the case where the Samurai object with the provided ID doesn't exist
                return false;
            }

            // Call the Delete method in your repository to delete the Samurai object
            return _weaponRepo.Delete(weaponToDelete);
        }
        [HttpPut("{id}")]
        public ActionResult<Weapon> Update(int id, Weapon weapon)
        {
            if (id != weapon.WeaponId)
            {
                return BadRequest("ID in the request path does not match the ID in the provided entity.");
            }

            var existingWeapon = _weaponRepo.GetById(id);
            if (existingWeapon == null)
            {
                return NotFound();
            }

            // Ensure that the ID of the provided entity matches the ID in the request path
            weapon.WeaponId = id;

            _weaponRepo.Update(weapon);
            return Ok(weapon);
        }

        [HttpGet("{id}")]
        public ActionResult<Weapon> GetById(int id)
        {
            var weapon = _weaponRepo.GetById(id);
            if (weapon == null)
            {
                return NotFound();
            }
            return weapon;
        }
    }
}
