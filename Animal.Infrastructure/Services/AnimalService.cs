using Animal.Infrastructure.Entities;
using Animal.Infrastructure.Interfaces;
using Animal.Infrastructure.Models.Animal;

namespace Animal.Infrastructure.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IRepository<AnimalEntity> _repository;
        private readonly IRepository<Specie> _specieRepository;

        public AnimalService(IRepository<AnimalEntity> repository, IRepository<Specie> specieRepository)
        {
            _repository = repository;
            _specieRepository = specieRepository;
        }

        public bool Create(AnimalCreateModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
                throw new ArgumentException("Animal name cannot be empty.");
            if (!_specieRepository.GetQuery().Any(x => x.Id == model.SpecieId))
                throw new ArgumentException("Specie by id not found.");
            if (string.IsNullOrWhiteSpace(model.Description))
                throw new ArgumentException("Animal description cannot be empty.");

            if (!_repository.GetQuery().Any(x => x.Name == model.Name))
            {
                _repository.Add(new AnimalEntity { 
                    Name = model.Name,  
                    Description = model.Description, 
                    SpecieId = model.SpecieId 
                });
                _repository.SaveChanges();
                Console.WriteLine("Animal added");
                return true;
            }
            Console.WriteLine("Animal with name {0} already exists.", model.Name);
            return false;
        }

        public List<AnimalEntity> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        public AnimalEntity? GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool Update(int id, string newName = "", string newDescription = "", int specie_id = 0)
        {
            var animal = _repository.GetById(id);
            if (animal == null)
                throw new ArgumentException("Animal not found.");
            if (specie_id > 0)
            {
                Specie specie = _specieRepository.GetById(specie_id);
                if (specie == null)
                    throw new ArgumentException("Specie by id not found.");
                animal.Specie = specie;
                animal.SpecieId = specie_id;
            }

            if (!string.IsNullOrWhiteSpace(newName))
            {
                if (!_repository.GetQuery().Any(x => x.Name == newName))
                    animal.Name = newName;
                else throw new ArgumentException("Animal with name {0} already exists.", newName);
            }
            if (!string.IsNullOrWhiteSpace(newDescription))
                animal.Description = newDescription;
            _repository.Update(animal);
            _repository.SaveChanges();
            Console.WriteLine("Animal updated");
            return true;
        }

        public bool Delete(int id)
        {
            var animal = _repository.GetById(id);
            if (animal != null)
            {
                _repository.Delete(animal);
                _repository.SaveChanges();
                Console.WriteLine("Animal deleted");
                return true;
            }
            return true;
        }
    }
}
