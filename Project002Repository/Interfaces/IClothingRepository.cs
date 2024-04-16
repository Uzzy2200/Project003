using Project002Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002Repository.Interfaces
{
    public interface IClothingRepository
    {
        Clothes Create(Clothes clothes);
        Clothes Update(Clothes clothes);
        List<Clothes> GetAll();
        Clothes GetById(int id);
        bool Delete(Clothes clothes);
        bool Save();
    }
}
