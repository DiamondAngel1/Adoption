using Animal.Infrastructure.Entities;
using Animal.Infrastructure.Models.Animal;

namespace Animal.Infrastructure.Interfaces
{
    public interface IAnimalService
    {
        bool Create(AnimalCreateModel model);
        List<AnimalEntity> GetAll();
        AnimalEntity? GetById(int id);
        bool Update(int id, string newName = "", string newDescription = "", int specie_id = 0);
        bool Delete(int id);
    }
}
