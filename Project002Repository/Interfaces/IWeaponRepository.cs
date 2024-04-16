using Project002.Repository.Models;
using Project002Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002Repository.Interfaces
{
    public interface IWeaponRepository
    {
        Weapon Create(Weapon weapon);
        Weapon Update(Weapon weapon);
        List<Weapon> GetAll();
        Weapon GetById(int id);
        bool Delete(Weapon weapon);
        bool Save();
    }
}
