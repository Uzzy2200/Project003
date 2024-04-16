using Project002Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002Repository.Interfaces
{
    public interface IHorseRepository
    {
        Horses Create(Horses horses);
        Horses Update(Horses country);
        List<Horses> GetAll();
        Horses GetById(int id);
        bool Delete(Horses horses);
        bool Save();
    }
}
