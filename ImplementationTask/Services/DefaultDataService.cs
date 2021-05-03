using ImplementationTask.Data.Repositories;
using ImplementationTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImplementationTask.Services
{
    public class DefaultDataService : IDataService
    {
        private readonly IRepository Repository;
        public DefaultDataService(IRepository repository)
        {
            this.Repository = repository;
        }

        public async Task<User> GetUserByIdAsync(long id)
        {
            var userEntity = await Repository.GetUserByIdAsync(id);
            if (userEntity == null) return null;

            return new User()
            {
                id = userEntity.Id,
                name = userEntity.Name
            };
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var userList = await Repository.GetUsersAsync();
            return this.PrepareUsers(userList);
        }

        public async Task<List<User>> SearchUsersAsync(string name)
        {
            var userList = await Repository.SearchUsersAsync(name);
            return this.PrepareUsers(userList);
        }

        public async Task<bool> Save(UserSave action)
        {
            Data.Models.UserAction userAction = new Data.Models.UserAction();
            userAction.Action = action.action;
            userAction.TimeStamp = action.timestamp;
            userAction.UserId = action.userId;
            return await Repository.Save(userAction);
        }

        private List<User> PrepareUsers(List<Data.Models.User> userList)
        {
            List<User> users = new List<User>();
            foreach (var user in userList)
            {
                users.Add(new User() { id = user.Id, name = user.Name });
            }
            return users;
        }
    }
}
