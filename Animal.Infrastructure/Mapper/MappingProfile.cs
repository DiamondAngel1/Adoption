using Animal.Infrastructure.Entities;
using Animal.Infrastructure.Models.Animal;
using AutoMapper;

namespace Animal.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Автоматично присвоїть одні поля одного об'єякта іншому об'єкту
            CreateMap<AnimalCreateModel, AnimalEntity>();
        }
    }
}
