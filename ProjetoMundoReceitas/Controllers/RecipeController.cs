using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoMundoReceitas.Data;
using ProjetoMundoReceitas.Dto.Recipe;
using ProjetoMundoReceitas.Models;

namespace ProjetoMundoReceitas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : Controller
    {
        private readonly DataContext _context;
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public RecipeController(DataContext context, IRepository repo, IMapper mapper) { 
        _context = context;
           _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Get() {
           var result = _repo.GetRecipes(true);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult Post(CreateRecipeDto model)

        {

            var recipeDto = _mapper.Map<Recipe>(model);
            _repo.Add(recipeDto);
            if (_repo.SaveChanges())
            {
                return Ok("Receita Criada");
            }
            return BadRequest("Não foi possivel criar Receita");
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Recipe recipe)
        {
            var recip = _context.Recipers.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (recip == null) return BadRequest("Receita não encontrada");

            _repo.Update(recipe);
            if (_repo.SaveChanges())
            {
                return Ok("Receita Atualizada");
            }
            return BadRequest("Não foi possivel atualizar Receita");
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var recipe = _context.Users.AsNoTracking().FirstOrDefault(x => x.Id == id);
            _repo.Add(recipe);
            if (_repo.SaveChanges())
            {
                return Ok("Receita Deletada");
            }
            return BadRequest("Não foi possivel deletar Receita");
        }

    }
}
