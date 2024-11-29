using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoMundoReceitas.Data;
using ProjetoMundoReceitas.Dto.User;
using ProjetoMundoReceitas.Helpers;
using ProjetoMundoReceitas.Models;
using SQLitePCL;

namespace ProjetoMundoReceitas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly DataContext _context;
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        public UserController(DataContext context, IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery]PageParams pageParams)
        {
            var result = await _repo.GetUsersAsync(pageParams);
            return Ok(_mapper.Map<IEnumerable<UserDto>>(result));
        }


        [HttpPost]
        public ActionResult Post(User user)
        {
            _repo.Add(user);
            if (_repo.SaveChanges())
            {
                return Ok("Usuário Cadastrado");
            }
            return BadRequest("Usuário não cadastrado");
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, User user)
        {
            var use = _context.Users.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (use == null) return BadRequest("Usuário não encontrado");

            _repo.Update(user);
            if (_repo.SaveChanges())
            {
                return Ok("Usuário Atualizado");
            }
            return BadRequest("Usuário não Atualizado");
        }
    }
}
