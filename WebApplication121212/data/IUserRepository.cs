using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication121212.Models;

namespace WebApplication121212.data
{
    public interface IUserRepository<T>
    {
        Task< IEnumerable<T>> GetUsers();
       Task <T> GetUserById(int id);
        Task<T> UpdateUser(T user,int id);
        Task<T> RemoveUser(int id);
       Task< T> AddUser(T user);


    }
}
