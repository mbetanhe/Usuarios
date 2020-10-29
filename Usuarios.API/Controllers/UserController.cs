using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Usuarios.CORE.Interfaces;

namespace Usuarios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) => _userRepository = userRepository;

        /// <summary>
        /// Retornamos todos los usuarios
        /// </summary>
        /// <returns>Retorna una lista de usuarios</returns>
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            IEnumerable<CORE.Entities.User> result = await _userRepository.GetUsers();

            return Ok(result);
        }
    }
}