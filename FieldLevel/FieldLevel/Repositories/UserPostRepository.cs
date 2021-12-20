using FieldLevel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace FieldLevel.Repositories {
    public class UserPostRepository : IUserPostRepository {
        private HttpClient _httpClient;
        public UserPostRepository(IHttpClientFactory factory) {
            this._httpClient = factory.CreateClient("postsApiEndpoint");
        }
        public async Task<IEnumerable<UserPost>> GetAllAsync() {
            var response = await _httpClient.GetAsync("/posts");
            return JsonSerializer.Deserialize(await response.Content.ReadAsStringAsync(), typeof(IEnumerable<UserPost>)) as IEnumerable<UserPost>;
        }
    }
}
