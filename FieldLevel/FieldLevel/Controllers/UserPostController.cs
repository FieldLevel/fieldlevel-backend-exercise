using FieldLevel.Models;
using FieldLevel.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FieldLevel.Controllers {
    [Route("")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserPostController : Controller {
        private ILogger<UserPostController> _logger;
        private IUserPostService _fetchService;
        public UserPostController(ILogger<UserPostController> logger, IUserPostService fetchService) {
            this._logger = logger;
            this._fetchService = fetchService;
        }
        /// <summary>
        /// Retrieves the latest post for each user.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<IEnumerable<UserPost>> Get() {
            return this._fetchService.LatestPostsAsync();
        }
    }
}
