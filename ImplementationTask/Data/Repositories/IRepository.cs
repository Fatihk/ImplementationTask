using ImplementationTask.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImplementationTask.Data.Repositories
{
    public interface IRepository
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(long id);
        Task<List<User>> SearchUsersAsync(string name);
        Task<bool> Save(UserAction action);
    }
}
