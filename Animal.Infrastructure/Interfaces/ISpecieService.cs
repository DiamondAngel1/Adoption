using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animal.Infrastructure.Entities;

namespace Animal.Infrastructure.Interfaces
{
    public interface ISpecieService
    {
        Specie CreateSpecie(string name);
        List<Specie> GetAllSpecies();
        Specie? GetSpecieById(int id);
        bool UpdateSpecie(int id, string newName);
        bool DeleteSpecie(int id);
    }
}
