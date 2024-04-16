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
    public class ClanRepo : IClanRepository
    {
        private readonly Dbcontext context;
        public ClanRepo(Dbcontext data)
        {
            this.context = data;
        }
        public Clan Create(Clan clan)
        {
            context.Clan.Add(clan);
            context.SaveChanges();
            return clan;
        }

        public List<Clan> GetAll()
        {
            return context.Clan.ToList();
        }
        public Clan GetById(int id)
        {
            return context.Clan.FirstOrDefault(c => c.ClanId == id);
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public Clan Update(Clan clan)
        {
            var existingClan = context.Clan.Find(clan.ClanId);
            if (existingClan == null)
            {
                throw new ArgumentException("Clan not found");
            }

            // Update properties of the existingSamurai entity except for the ID
            context.Entry(existingClan).CurrentValues.SetValues(clan);

            context.SaveChanges();
            return existingClan;
        }
        public bool Delete(Clan clan)
        {
            try
            {
                context.Clan.Remove(clan);
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
