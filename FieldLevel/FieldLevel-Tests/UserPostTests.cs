using FieldLevel.Repositories;
using FieldLevel.Services;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FieldLevel_Tests {
    public class Tests {
        readonly IServiceProvider _services = FieldLevel.Program.CreateHostBuilder(new string[] { }).Build().Services;
        ILogger<UserPostService> logger;
        ICacheService cache;
        IUserPostRepository repo;
        [SetUp]
        public void Setup() {
            logger = _services.GetService(typeof(ILogger<UserPostService>)) as ILogger<UserPostService>;
            cache = _services.GetService(typeof(ICacheService)) as ICacheService;
            repo = _services.GetService(typeof(IUserPostRepository)) as IUserPostRepository;
        }

        [Test]
        public async Task TestCachingServiceWorksFrom5Seconds() {
            IUserPostService service = new UserPostService(logger, repo, cache);
            var result1 = await service.LatestPostsAsync();
            await Task.Delay(TimeSpan.FromSeconds(5));
            var result2 = await service.LatestPostsAsync();

            Assert.IsTrue(result1.First().createdOn == result2.First().createdOn);
        }
        [Test]
        public async Task TestCachingServiceWorksFrom61Seconds() {
            IUserPostService service = new UserPostService(logger, repo, cache);
            var result1 = await service.LatestPostsAsync();
            await Task.Delay(TimeSpan.FromSeconds(61));
            var result2 = await service.LatestPostsAsync();

            Assert.IsTrue(result1.First().createdOn != result2.First().createdOn);
        }
    }
}