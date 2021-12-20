using FieldLevel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FieldLevel.Services {
    public interface IUserPostService {
        Task<IEnumerable<UserPost>> LatestPostsAsync();
    }
}
