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
    public class CountryController : ControllerBase
    {

            private readonly ICountryRepository _countryRepo;

            public CountryController(ICountryRepository countryRepo)
            {
                _countryRepo = countryRepo;
            }

            // GET: api/<CountryController>
            [HttpGet]
        public IEnumerable<Country> GetAll()
        {
            var result = _countryRepo.GetAll();
            return result;
        }
        [HttpPost]
        public void Create(Country country)
        {
            _countryRepo.Create(country);
        }

  

        // DELETE api/<SamuraiController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            // Retrieve the Samurai object from the database using the provided ID
            Country countryToDelete = _countryRepo.GetAll().FirstOrDefault(c => c.CountryId == id);

            if (countryToDelete == null)
            {
                // Return false or handle the case where the Samurai object with the provided ID doesn't exist
                return false;
            }

            // Call the Delete method in your repository to delete the Samurai object
            return _countryRepo.Delete(countryToDelete);
        }
        [HttpPut("{id}")]
        public ActionResult<Country> Update(int id, Country country)
        {
            if (id != country.CountryId)
            {
                return BadRequest("ID in the request path does not match the ID in the provided entity.");
            }

            var existingCountry = _countryRepo.GetById(id);
            if (existingCountry == null)
            {
                return NotFound();
            }

            // Ensure that the ID of the provided entity matches the ID in the request path
            country.CountryId = id;

            _countryRepo.Update(country);
            return Ok(country);
        }


        [HttpGet("{id}")]
        public ActionResult<Country> GetById(int id)
        {
            var country = _countryRepo.GetById(id);
            if (country == null)
            {
                return NotFound();
            }
            return country;
        }

    }
}
