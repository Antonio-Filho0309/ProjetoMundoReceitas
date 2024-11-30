using AutoMapper;
using ProjetoMundoReceitas.Data;
using ProjetoMundoReceitas.Dto.User;
using ProjetoMundoReceitas.Models;
using ProjetoMundoReceitas.Repositories.Interface;
using ProjetoMundoReceitas.Service.Interfaces;

namespace ProjetoMundoReceitas.Service
{
    public class UserServices : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UserServices(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ResultService<CreateUserDto>> CreateAsync(CreateUserDto createUserDto)
        {
            if (createUserDto == null)
                return ResultService.Fail<CreateUserDto>("Objeto deve ser informado");
            
            var user = _mapper.Map<User>(createUserDto);
            var data = await _repo.Add(user);
            return ResultService.Ok<CreateUserDto>(_mapper.Map<CreateUserDto>(data));
        
        }

        public async Task<ResultService<ICollection<UserDto>>> GetAllAsync()
        {
           var user = await _repo.GetAllUsers();
            return ResultService.Ok<ICollection<UserDto>>(_mapper.Map<ICollection<UserDto>>(user));
        }

        public async Task<ResultService> UpdateAsync(UpdateUserDto updateUserDto)
        {
            if (updateUserDto == null)
                return ResultService.Fail("Objeto deve ser informado");

            var user = await _repo.GetUserById(updateUserDto.Id);
            if (user == null)
                return ResultService.Fail("Pessoa não encontrada");
            user = _mapper.Map<UpdateUserDto, User>(updateUserDto, user);
            await _repo.Update(user);
            return ResultService.Ok("Pessoa editada");
        }
    }
}
