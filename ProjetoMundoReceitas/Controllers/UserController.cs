using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoMundoReceitas.Data;
using ProjetoMundoReceitas.Dto.User;
using ProjetoMundoReceitas.Helpers;
using ProjetoMundoReceitas.Models;
using ProjetoMundoReceitas.Models.FilterDb;
using ProjetoMundoReceitas.Repositories.Interface;
using ProjetoMundoReceitas.Service.Interfaces;
using SQLitePCL;

namespace ProjetoMundoReceitas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _service;
        public UserController(IUserService userService)
        {
          _service = userService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _service.GetAllAsync();
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);

        }

        [HttpGet]
        [Route("paged")]
        public async Task<ActionResult> GetPagedAsync([FromQuery] FilterDb userFilterDb)
        {
            var result = await _service.GetPagedAsync(userFilterDb);
            if (result.IsSucess)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody]CreateUserDto createUserDto)
        {
           var result = await _service.CreateAsync(createUserDto);
            if(result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] UpdateUserDto updateUserDto)
        {
            var result = await _service.UpdateAsync(updateUserDto);
            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);
        }

    }
}
