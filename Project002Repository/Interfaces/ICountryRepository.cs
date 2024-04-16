using Project002.Repository.Models;
using Project002Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002Repository.Interfaces
{
    public interface ICountryRepository
    {
        Country Create(Country country);
        Country Update(Country country);
        List<Country> GetAll();
        Country GetById(int id);
        bool Delete(Country country);
        bool Save();
    }
}
