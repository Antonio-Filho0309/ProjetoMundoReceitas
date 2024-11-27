using Microsoft.AspNetCore.Mvc;

namespace ProjetoMundoReceitas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : Controller
    {
        public RecipeController() { }

        [HttpGet]
        public ActionResult Get() {

            return Ok();
        }
        
    }
}
