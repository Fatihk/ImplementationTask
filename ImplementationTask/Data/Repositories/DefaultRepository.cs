using ImplementationTask.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImplementationTask.Data.Repositories
{
    public class DefaultRepository : IRepository
    {
        private readonly DataContext DataContext;
        public DefaultRepository(DataContext dataContext)
        {
            this.DataContext = dataContext;
        }
        public async Task<List<User>> GetUsersAsync()
        {
            return await DataContext.Users.ToListAsync();
        }
        public async Task<User> GetUserByIdAsync(long id)
        {
            return await DataContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<List<User>> SearchUsersAsync(string name)
        {
            var users = await DataContext
                .Users
                .Where(
                    u => u.Name.Contains(name)
                ).ToListAsync();
            return users;
        }

        public async Task<bool> Save(UserAction action)
        {
            DataContext.UserActions.Add(action);
            var result = await DataContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
