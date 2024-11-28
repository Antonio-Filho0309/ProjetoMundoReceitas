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
            
            if (model.Image != null && model.Image.Length > 0)
            {
               
                using (var memoryStream = new MemoryStream())
                {
                     model.Image.CopyTo(memoryStream);
                    var imageBytes = memoryStream.ToArray();
                    model.Image = null; 

                   
                    var recipeDto = _mapper.Map<Recipe>(model);
                    recipeDto.Image = imageBytes; // Adiciona a imagem convertida ao Recipe

                    _repo.Add(recipeDto);
                    if (_repo.SaveChanges())
                    {
                        return Ok("Receita Criada");
                    }
                }
            }
            else
            {
                // Se não tiver imagem, apenas mapeia e salva sem a imagem
                var recipeDto = _mapper.Map<Recipe>(model);
                _repo.Add(recipeDto);
                if (_repo.SaveChanges())
                {
                    return Ok("Receita Criada sem Imagem");
                }
            }

            return BadRequest("Não foi possível criar a Receita");
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, UpdateRecipeDto model)
        {
            var recip = _context.Recipers.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (recip == null) return BadRequest("Receita não encontrada");

            _mapper.Map(model, recip);

            _repo.Update(recip);
            if (_repo.SaveChanges())
            {
                return Ok("Receita Atualizada");
            }
            return BadRequest("Não foi possivel atualizar Receita");
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var recipe = _context.Recipers.AsNoTracking().FirstOrDefault(x => x.Id == id);
            _repo.Delete(recipe);
            if (_repo.SaveChanges())
            {
                return Ok("Receita Deletada");
            }
            return BadRequest("Não foi possivel deletar Receita");
        }

    }
}
