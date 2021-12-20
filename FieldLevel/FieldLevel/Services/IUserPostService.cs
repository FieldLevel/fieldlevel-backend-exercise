using FieldLevel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FieldLevel.Services {
    public interface IUserPostService {
        Task<IEnumerable<UserPost>> LatestPostsAsync();
    }
}
