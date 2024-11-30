using ProjetoLivrariaAPI.Models.Dtos;
using ProjetoMundoReceitas.Dto;
using ProjetoMundoReceitas.Dto.User;
using ProjetoMundoReceitas.Models;
using ProjetoMundoReceitas.Models.FilterDb;
using ProjetoMundoReceitas.Pagination;

namespace ProjetoMundoReceitas.Service.Interfaces
{
    public interface IUserService
    {
        Task<ResultService<CreateUserDto>> CreateAsync(CreateUserDto createUserDto);
        Task<ResultService<ICollection<UserDto>>> GetAllAsync();
        Task<ResultService> UpdateAsync(UpdateUserDto updateUserDto);

        Task<ResultService<PagedBaseResponseDto<UserDto>>> GetPagedAsync(FilterDb filterDb);
    }
}
