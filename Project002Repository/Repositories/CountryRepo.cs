using Project002Repository.Interfaces;
using Project002.Repository.Models;
using Project002Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project002Repository.Migrations;

namespace Project002Repository.Repositories
{
    public class CountryRepo : ICountryRepository
    {
        private readonly Dbcontext context;
        public CountryRepo(Dbcontext data)
        {
            this.context = data;
        }
        public Country Create(Country country)
        {
            context.Country.Add(country);
            context.SaveChanges();
            return country;
        }

        public List<Country> GetAll()
        {
            return context.Country.ToList();
        }
        public Country GetById(int id)
        {
            return context.Country.FirstOrDefault(c => c.CountryId == id);
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public Country Update(Country country)
        {
            var existingCountry = context.Country.Find(country.CountryId);
            if (existingCountry == null)
            {
                throw new ArgumentException("Country not found");
            }

            // Update properties of the existingSamurai entity except for the ID
            context.Entry(existingCountry).CurrentValues.SetValues(country);

            context.SaveChanges();
            return existingCountry;
        }
        public bool Delete(Country country)
        {
            try
            {
                context.Country.Remove(country);
                context.SaveChanges();
                return true; // Indicate successful deletion
            }
            catch (Exception ex)
            {
                // Handle exception or log error
                return false; // Indicate deletion failure
            }
        }

    }
}
