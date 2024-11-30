using ProjetoMundoReceitas.Dto.User;
using ProjetoMundoReceitas.Models;

namespace ProjetoMundoReceitas.Service.Interfaces
{
    public interface IUserService
    {
        Task<ResultService<CreateUserDto>> CreateAsync(CreateUserDto createUserDto);
        Task<ResultService<ICollection<UserDto>>> GetAllAsync();
        Task<ResultService> UpdateAsync(UpdateUserDto updateUserDto);
    }
}
