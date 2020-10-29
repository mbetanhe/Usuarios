using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios.CORE.Entities;
using Usuarios.CORE.Interfaces;

namespace Usuarios.INFRASTRUCTURE.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<IEnumerable<User>> GetUsers()
        {
            var result = Enumerable.Range(1, 10).Select(x => new User
            {
                Iduser = x,
                Cardid = x*2,
                Name = $"Nombre {x}",
                Lastname = $"Apellido {x}",
                Id = $"{x * 1234}",
                Email = $"email@email{x}.com",
                Password = "1234"
            });

            await Task.Delay(100);

            return result;
        }
    }
}
