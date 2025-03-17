using Animal.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
namespace Animal.Infrastructure{
    public class DatabaseSeeder(AppAnimalContext context){
        public void SeedData(){
            context.Database.Migrate();
            if(!context.ShelterLocations.Any()){
                var kiev = new ShelterLocation{
                    Adress = "вул. Центральна, 10, Київ",
                    Name = "Центральний притулок",
                    Phone = "+(380) 66 046 7433"
                };
                context.ShelterLocations.Add(kiev);
                var lviv = new ShelterLocation{
                    Adress = "вул. Західна, 5, Львів",
                    Name = "Західний притулок",
                    Phone = "+(380) 95 237 2310"
                };
                context.ShelterLocations.Add(lviv);
                context.SaveChanges();
            }
            if (!context.Species.Any()){
                context.Species.Add(new Specie { Name = "Кіт" });
                context.Species.Add(new Specie { Name = "Собака" });
                context.Species.Add(new Specie { Name = "Білка" });
                context.Species.Add(new Specie { Name = "Бобер" });
                context.Species.Add(new Specie { Name = "Хом'як" });
                context.SaveChanges();
            }
            if (!context.Animals.Any()) {
                var cat = new AnimalEntity{
                    Name = "Барсик",
                    SpecieId = 1,
                    Breed = "Персийський",
                    Age = 3,
                    Gender = "Чоловіча",
                    ArrivalDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-1).AddDays(-6)),
                    SheltherLocationId = 1,
                };
                var dog = new AnimalEntity{
                    Name = "Рекс",
                    SpecieId = 2,
                    Breed = "Німецька вівчарка",
                    Age = 6,
                    Gender = "Чоловіча",
                    ArrivalDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-2).AddDays(-1)),
                    SheltherLocationId = 1,
                };
                context.Animals.Add(cat);
                context.Animals.Add(dog);
                context.SaveChanges();
            }
            if (!context.Adopters.Any()){
                var adopter1 = new Adopter{
                    FirstName = "Олександр",
                    LastName = "Петров",
                    Phone = "+380931234567",
                    Email = "petrov@example.com",
                    Address = "вул. Шевченка, 15",
                };
                var adopter2 = new Adopter{
                    FirstName = "Марія",
                    LastName = "Іваненко",
                    Phone = "+380671112233",
                    Email = "ivanenko@example.com",
                    Address = "вул. Лесі Українки, 20, Львів",
                };
                context.Add(adopter1);
                context.Add(adopter2);
                context.SaveChanges();
            }
            if (!context.Employees.Any()) {
                var employee1 = new Employee{
                    FirstName = "Анна",
                    LastName = "Сидоренко",
                    Position = "Ветерианр",
                    HireDate = DateOnly.FromDateTime(DateTime.Parse("2022-06-01")),
                    ShelterLocationId = 1,
                };
                var employee2 = new Employee{
                    FirstName = "Ігор",
                    LastName = "Коваленко",
                    Position = "Адміністратор",
                    HireDate = DateOnly.FromDateTime(DateTime.Parse("2023-02-15")),
                    ShelterLocationId = 2,
                };
                context.Add(employee1);
                context.Add(employee2);
                context.SaveChanges();
            }
            if (!context.Adoptions.Any()) {
                var adoption = new Adoption{
                    AnimalId = 1,
                    AdopterId = 1,
                    AdoptionDate = DateOnly.FromDateTime(DateTime.Parse("2024-02-01")),
                };
                context.Add(adoption);
                context.SaveChanges();
            }
            if (!context.MedicalRecords.Any()) {
                var record = new MedicalRecord{
                    AnimalId = 1,
                    CheckupDate = DateOnly.FromDateTime(DateTime.Parse("2024-02-05")),
                    Diagnosis = "Здоровий",
                    Treatment = "Не потрибує лікування",
                    VetName = "Анна Сидоренко",
                };
                context.Add(record);
                context.SaveChanges();
            }
        }
    }
}