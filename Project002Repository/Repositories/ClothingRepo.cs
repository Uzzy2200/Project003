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
    public class ClothingRepo : IClothingRepository
    {
        private readonly Dbcontext context;
        public ClothingRepo(Dbcontext data)
        {
            this.context = data;
        }
        public Clothes Create(Clothes clothes)
        {
            context.Clothes.Add(clothes);
            context.SaveChanges();
            return clothes;
        }
        public List<Clothes> GetAll()
        {
            return context.Clothes.ToList();
        }
        public Clothes GetById(int id)
        {
            return context.Clothes.FirstOrDefault(c => c.ClothingId == id);
        }


        public bool Delete(Clothes clothes)
        {
            try
            {
                context.Clothes.Remove(clothes);
                context.SaveChanges();
                return true; // Indicate successful deletion
            }
            catch (Exception ex)
            {
                // Handle exception or log error
                return false; // Indicate deletion failure
            }
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public Clothes Update(Clothes clothes)
        {
            var existingClothing = context.Clothes.Find(clothes.ClothingId);
            if (existingClothing == null)
            {
                throw new ArgumentException("Clothes not found");
            }

            // Update properties of the existingSamurai entity except for the ID
            context.Entry(existingClothing).CurrentValues.SetValues(clothes);

            context.SaveChanges();
            return existingClothing;
        }
    }
}
