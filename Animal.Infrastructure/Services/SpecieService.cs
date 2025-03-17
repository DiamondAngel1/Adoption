using Animal.Infrastructure.Entities;
using Animal.Infrastructure.Interfaces;

namespace Animal.Infrastructure.Services
{
    public class SpecieService : ISpecieService
    {
        private readonly IRepository<Specie> _repository;

        public SpecieService(IRepository<Specie> repository)
        {
            _repository = repository;
        }

        public Specie CreateSpecie(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Specie name cannot be empty.");

            var entity = _repository.GetQuery()
                .Where(s => s.Name == name);
            if(entity.Any())
            {
                throw new Exception("------Такий бармалей уже є :)------");
            }

            var specie = new Specie { Name = name };
            _repository.Add(specie);
            _repository.SaveChanges();
            return specie;
        }

        public List<Specie> GetAllSpecies()
        {
            return _repository.GetAll().ToList();
        }

        public Specie? GetSpecieById(int id)
        {
            return _repository.GetById(id);
        }

        public bool UpdateSpecie(int id, string newName)
        {
            var specie = _repository.GetById(id);
            if (specie == null) return false;

            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Specie name cannot be empty.");

            specie.Name = newName;
            _repository.Update(specie);
            _repository.SaveChanges();
            return true;
        }

        public bool DeleteSpecie(int id)
        {
            var specie = _repository.GetById(id);
            if (specie == null) return false;

            _repository.Delete(specie);
            _repository.SaveChanges();
            return true;
        }
    }
}
