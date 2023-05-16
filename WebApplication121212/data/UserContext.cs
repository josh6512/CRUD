using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication121212.Models;

namespace WebApplication121212.data
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> option) : base(option)
        {

        }
        public DbSet<User> user { get; set; }
    }
}
