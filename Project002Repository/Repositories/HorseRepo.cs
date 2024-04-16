using Project002.Repository.Models;
using Project002Repository.Interfaces;
using Project002Repository.Migrations;
using Project002Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002Repository.Repositories
{
    public class HorseRepo : IHorseRepository
    {
        private readonly Dbcontext context;
        public HorseRepo(Dbcontext data)
        {
            this.context = data;
        }
        public Horses Create(Horses horses)
        {
            context.Horses.Add(horses);
            context.SaveChanges();
            return horses;
        }

        public bool Delete(Horses horses)
        {
            try
            {
                context.Horses.Remove(horses);
                context.SaveChanges();
                return true; // Indicate successful deletion
            }
            catch (Exception ex)
            {
                // Handle exception or log error
                return false; // Indicate deletion failure
            }
        }

        public List<Horses> GetAll()
        {
            return context.Horses.ToList();
        }

        public Horses GetById(int id)
        {
            return context.Horses.FirstOrDefault(h => h.HorseId == id);
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public Horses Update(Horses horses)
        {
            var existingHorse = context.Horses.Find(horses.HorseId);
            if (existingHorse == null)
            {
                throw new ArgumentException("Horse not found");
            }

            // Update properties of the existingSamurai entity except for the ID
            context.Entry(existingHorse).CurrentValues.SetValues(horses);

            context.SaveChanges();
            return existingHorse;
        }
    }
}
