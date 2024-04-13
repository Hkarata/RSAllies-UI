using Newtonsoft.Json;
using RSAllies.Contracts;
using RSAllies.HelperTypes;

namespace RSAllies
{
    public class ApiClient(HttpClient httpClient)
    {
        public async Task<Result<UserDTO>> CreateUserAsync(UserDTO user)
        {
            var response = await httpClient.PostAsJsonAsync<UserDTO>("/api/users", user);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Result<UserDTO>>(content)!;
            return result;
        }

        public async Task<Result<Guid>> GetCheckUserAsync(UserDTO user)
        {
            var response = await httpClient.PostAsJsonAsync<UserDTO>("/api/user/check-user", user);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Result<Guid>>(content)!;
            return result;
        }

        public async Task<Result<UserDTO>> GetUserAsync(Guid id)
        {

           var response = await httpClient.GetAsync($"/api/user/{id}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Result<UserDTO>>(content)!;
            return result;
        }
    }
}
