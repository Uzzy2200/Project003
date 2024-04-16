using Microsoft.EntityFrameworkCore;
using Project002.Repository.Models;
using Project002Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002Repository.Repositories
{
    public class SamuraiRepo : ISamuraiRepository
    {
        private readonly Dbcontext context;

        public SamuraiRepo(Dbcontext data)
        {
            this.context = data;
        }
        public Samurai Create(Samurai samurai)
        {
            //context is our database
            //Samurai is our table
            context.Samurai.Add(samurai);
            context.SaveChanges();
            return samurai;
        }

        public bool Delete(Samurai samurai)
        {
            try
            {
                context.Samurai.Remove(samurai);
                context.SaveChanges();
                return true; // Indicate successful deletion
            }
            catch (Exception ex)
            {
                // Handle exception or log error
                return false; // Indicate deletion failure
            }
        }

        public List<Samurai> GetAll()
        {
            return context.Samurai.ToList();
        }
        public Samurai GetById(int id)
        {
            return context.Samurai.FirstOrDefault(s => s.Id == id);
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public Samurai Update(Samurai samurai)
        {
            var existingSamurai = context.Samurai.Find(samurai.Id);
            if (existingSamurai == null)
            {
                throw new ArgumentException("Samurai not found");
            }

            // Update properties of the existingSamurai entity except for the ID
            context.Entry(existingSamurai).CurrentValues.SetValues(samurai);

            context.SaveChanges();
            return existingSamurai;
        }

    }
}
