using Project002.Repository.Models;
using Project002Repository.Interfaces;
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
            throw new NotImplementedException();
        }

        public bool Delete(Horses horses)
        {
            throw new NotImplementedException();
        }

        public List<Horses> GetAll()
        {
            throw new NotImplementedException();
        }

        public Horses GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public Horses Update(Horses country)
        {
            throw new NotImplementedException();
        }
    }
}
