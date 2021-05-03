using ImplementationTask.Data;
using ImplementationTask.Models;
using ImplementationTask.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImplementationTask.Controllers
{
    /// <summary>
    /// User Endpoint
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDataService DataService;
        public UserController(IDataService dataService)
        {
            this.DataService = dataService;
        }
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<ICollection<User>>), 200)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await DataService.GetUsersAsync();
                return ApiResponse<List<User>>(users, null);
            }
            catch (Exception ex)
            {
                return ApiErrorResponse(ex.Message, 500);
            }
        }
        /// <summary>
        /// Get single user
        /// </summary>
        /// <param name="id">By User Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<User>), 200)]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var user = await DataService.GetUserByIdAsync(id);
                if (user == null) return ApiErrorResponse("User not found!", 404);

                return ApiResponse<User>(user, null);
            }
            catch (Exception ex)
            {
                return ApiErrorResponse(ex.Message, 500);
            }
        }

        /// <summary>
        /// User search by name
        /// </summary>
        /// <param name="search">Filter</param>
        /// <returns></returns>
        [HttpPost("search")]
        [ProducesResponseType(typeof(ApiResponse<ICollection<User>>), 200)]
        public async Task<IActionResult> Search([FromBody] UserSearch search)
        {
            try
            {
                if (search.filter == null) return ApiErrorResponse("Filter does not empty!", 200);
                if (search.filter.name == null) return ApiErrorResponse("Name does not empty!", 200);

                var users = await DataService.SearchUsersAsync(search.filter.name);
                return ApiResponse<List<User>>(users, null);
            }
            catch (Exception ex)
            {
                return ApiErrorResponse(ex.Message, 500);
            }
        }

        /// <summary>
        /// Save user action
        /// </summary>
        /// <param name="action">Action details</param>
        /// <returns></returns>
        [HttpPatch("save")]
        [ProducesResponseType(typeof(ApiResponse<bool>), 200)]
        public async Task<IActionResult> Save([FromBody] UserSave action)
        {
            try
            {
                var user = await DataService.GetUserByIdAsync(action.userId);
                if (user == null) return ApiErrorResponse("User not found!", 404);

                var result = await DataService.Save(action);
                return ApiResponse<bool>(result, null);
            }
            catch (Exception ex)
            {
                return ApiErrorResponse(ex.Message, 500);
            }

        }

        protected IActionResult ApiResponse<T>(T data, string message = null)
        {
            return this.StatusCode(200, new ApiResponse<T>(data, message));
        }
        protected IActionResult ApiErrorResponse(string message = null, int errorCode = 500)
        {
            return this.StatusCode(errorCode, new ApiResponse<string>(message));
        }
    }
}
