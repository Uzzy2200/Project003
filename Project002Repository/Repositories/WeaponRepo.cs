using Project002Repository.Interfaces;
using Project002Repository.Models;
using Project002.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project002Repository.Migrations;

namespace Project002Repository.Repositories
{
    public class WeaponRepo : IWeaponRepository
    {
        private readonly Dbcontext context;

        public WeaponRepo(Dbcontext data)
        {
            this.context = data;
        }
        public Weapon Create(Weapon weapon)
        {
            //context is our database
            //Samurai is our table
            context.Weapon.Add(weapon);
            context.SaveChanges();
            return weapon;
        }

        public bool Delete(Weapon weapon)
        {
            try
            {
                context.Weapon.Remove(weapon);
                context.SaveChanges();
                return true; // Indicate successful deletion
            }
            catch (Exception ex)
            {
                // Handle exception or log error
                return false; // Indicate deletion failure
            }
        }


        public List<Weapon> GetAll()
        {
            return context.Weapon.ToList();
        }
        public Weapon GetById(int id)
        {
            return context.Weapon.FirstOrDefault(w => w.WeaponId == id);
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public Weapon Update(Weapon weapon)
        {
            var existingWeapon = context.Weapon.Find(weapon.WeaponId);
            if (existingWeapon == null)
            {
                throw new ArgumentException("Weapon not found");
            }

            // Update properties of the existingSamurai entity except for the ID
            context.Entry(existingWeapon).CurrentValues.SetValues(weapon);

            context.SaveChanges();
            return existingWeapon;
        }
    }
}
