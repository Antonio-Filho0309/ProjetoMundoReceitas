using AutoMapper;
using ProjetoMundoReceitas.Dto.Recipe;
using ProjetoMundoReceitas.Dto.User;
using ProjetoMundoReceitas.Models;

namespace ProjetoMundoReceitas.Helpers
{
    public class DataContextProfile : Profile
    {
        public DataContextProfile()
        {
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();


            CreateMap<CreateRecipeDto, Recipe>().ReverseMap();
            CreateMap<Recipe, UpdateRecipeDto>().ReverseMap();
                
        }
    }
}
