using Microsoft.AspNetCore.Mvc;
using ProjetoMundoReceitas.Models;

namespace ProjetoMundoReceitas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        public UserController() { }

        [HttpGet]
        public ActionResult Get() {

            return Ok();
        }


        [HttpPost]
        public ActionResult Post(User user) {
            return Ok(user);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, User user)
        {
            return Ok(user);
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }




    }
}
