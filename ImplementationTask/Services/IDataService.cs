using ImplementationTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImplementationTask.Services
{
    public interface IDataService
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(long id);
        Task<List<User>> SearchUsersAsync(string name);
        Task<bool> Save(UserSave action);
    }
}
