using Project002.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002Repository.Interfaces
{
    public interface ISamuraiRepository
    {
        Samurai Create(Samurai samurai);
        Samurai Update(Samurai samurai);
        List<Samurai> GetAll();

        Samurai GetById(int id);

        bool Delete(Samurai samurai);
        bool Save();
    }
}
