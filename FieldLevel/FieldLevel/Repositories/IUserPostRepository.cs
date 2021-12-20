using FieldLevel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FieldLevel.Repositories {
    public interface IUserPostRepository {
        Task<IEnumerable<UserPost>> GetAllAsync();
    }
}
