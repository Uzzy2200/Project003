using Project002.Repository.Models;
using Project002Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project002Repository.Interfaces
{
    public interface IWarRepository
    {
        War Create(War war);
        War Update(War war);
        List<War> GetAll();
        War GetById(int id);

        bool Delete(War war);
        bool Save();
    }
}
