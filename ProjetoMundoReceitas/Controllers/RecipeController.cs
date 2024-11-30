using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoMundoReceitas.Data;
using ProjetoMundoReceitas.Dto.Recipe;
using ProjetoMundoReceitas.Dto.User;
using ProjetoMundoReceitas.Models;
using ProjetoMundoReceitas.Models.FilterDb;
using ProjetoMundoReceitas.Repositories.Interface;
using ProjetoMundoReceitas.Service.Interfaces;

namespace ProjetoMundoReceitas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : Controller
    {
        private readonly IRecipeService _service;
     
        public RecipeController(IRecipeService service) { 
   
           _service = service;

        }

        [HttpGet]
        public async Task<ActionResult> GetAsync() {
           var result = await _service.GetAllAsync();
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }


        [HttpGet]
        [Route("paged")]
        public async Task<ActionResult> GetPagedAsync([FromQuery] FilterDb recipeFilterDb)
        {
            var result = await _service.GetPagedAsync(recipeFilterDb);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }



        [HttpPost]
        public async Task<ActionResult> PostAsync(CreateRecipeDto createRecipeDto)
        {
            var result = await _service.CreateAsync(createRecipeDto);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }


        [HttpPut]
        public async Task<ActionResult> UpdateAsync(UpdateRecipeDto updateRecipeDto)
        {
            var result = await _service.UpdateAsync(updateRecipeDto);

            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _service.Delete(id);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

    }
}
