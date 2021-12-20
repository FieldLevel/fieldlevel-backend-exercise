using FieldLevel.Models;
using FieldLevel.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FieldLevel.Services {
    public class UserPostService : IUserPostService {
        private ILogger<UserPostService> _logger;
        private IUserPostRepository _repository;
        private ICacheService _cachingService;
        public UserPostService(ILogger<UserPostService> logger, IUserPostRepository repository, ICacheService cachingService) {
            this._logger = logger;
            this._repository = repository;
            this._cachingService = cachingService;
        }
        public async Task<IEnumerable<UserPost>> LatestPostsAsync() {
            var results = await this._cachingService.GetOrSet("key", TimeSpan.FromMinutes(1), async () => {
                var all = await _repository.GetAllAsync();
                // box the results by the user then take the latest using id as the sorting order
                return all.GroupBy(
                            x => x.userId,
                            (x, y) => new {
                                Key = x,
                                Value = y.OrderByDescending(z => z.id).FirstOrDefault()
                            }
                        ).Select(g => g.Value);
            });

            return results;
        }
    }
}
