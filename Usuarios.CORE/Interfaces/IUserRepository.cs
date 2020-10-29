using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Usuarios.CORE.Entities;

namespace Usuarios.CORE.Interfaces
{
    public interface IUserRepository
    {
        //Task AddUser();

        Task<IEnumerable<User>> GetUsers();
    }
}
