using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication121212.Models;

namespace WebApplication121212.data
{
    public class UserRepository : IUserRepository<User> 
    {
        readonly UserContext userContext;

        public UserRepository(UserContext userContext)
        {
            this.userContext = userContext;
        }

        public async Task <User> AddUser(User user)
        {
            userContext.user.Add(user);
          await  userContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            return await userContext.user.FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task< IEnumerable<User>> GetUsers()
        {
            return await userContext.user.ToListAsync();
        }

        public async Task<User> RemoveUser(int id)
        {
           var exist = await userContext.user.FirstOrDefaultAsync(p => p.id == id);

            if (exist != null)
            {
                userContext.user.Remove(exist); // Assuming "Users" is the DbSet representing the User entity
                await userContext.SaveChangesAsync();
            }
            return exist;
        }

        public async Task<User> UpdateUser(User user,int id)
        {
            var existing = await GetUserById(id);
            if (existing != null)
            {
                existing.fullName = user.fullName;
                existing.mobile = user.mobile;
                existing.email = user.email;
                existing.age = user.age;
                existing.bloodGroup = user.bloodGroup;
                existing.address = user.address;
                ;
                userContext.user.Update(existing);
               await userContext.SaveChangesAsync();
            }
                return existing;
        }
    }
}
