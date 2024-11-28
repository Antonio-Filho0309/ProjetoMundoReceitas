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
            CreateMap<User, UserDto>(); 
            CreateMap<Recipe, CreateRecipeDto>().ReverseMap();
            CreateMap<Recipe, UpdateRecipeDto>().ReverseMap();
        }
    }
}
