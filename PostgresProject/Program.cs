using System.Text;
using Animal.Infrastructure;
using Animal.Infrastructure.Interfaces;
using Animal.Infrastructure.Models.Animal;
using Microsoft.Extensions.DependencyInjection;

namespace PostgresProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            var sp = DIConfiguration.GetServiceProvider();
            Console.WriteLine("Передаю вітання нашим друзям Броненосцям. :)!");
            var seder = sp.GetService<DatabaseSeeder>();
            seder.SeedData();
            //var specieService = sp.GetService<ISpecieService>();
            //var animalService = sp.GetService<IAnimalService>();


            //try
            //{
            //    var model = new AnimalCreateModel
            //    {
            //        Name = "Білий бобер",
            //        Description = "Часто може з'являтися при приступах агреції та " +
            //                        "неконтрольованому стані",
            //        SpecieId = 15
            //    };

            //    animalService.Create(model);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Щось пішло не так {ex.Message}");
            //}

            


            //try
            //{
            //    specieService.CreateSpecie("Кiт");
            //    specieService.CreateSpecie("Собака");
            //    specieService.CreateSpecie("Білка");
            //    specieService.CreateSpecie("Хом'як");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Виникла проблема {ex.Message}");
            //}

            //var list = specieService.GetAllSpecies();
            //foreach (var item in list)
            //{
            //    Console.WriteLine($"---{item.Id}-{item.Name}------");
            //}




        }
    }
}
