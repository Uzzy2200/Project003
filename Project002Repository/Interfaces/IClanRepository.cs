using Project002.Repository.Models;
using Project002Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002Repository.Interfaces
{
    public interface IClanRepository
    {
        Clan Create(Clan clan);
        Clan Update(Clan clan);
        List<Clan> GetAll();
        Clan GetById(int id);
        bool Delete(Clan clan);
        bool Save();
    }
}
