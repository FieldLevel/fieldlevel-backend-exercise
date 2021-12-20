using FieldLevel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FieldLevel.Repositories {
    public interface IUserPostRepository {
        Task<IEnumerable<UserPost>> GetAllAsync();
    }
}
