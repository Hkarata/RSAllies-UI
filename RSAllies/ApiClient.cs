using Newtonsoft.Json;
using RSAllies.Contracts;
using RSAllies.HelperTypes;

namespace RSAllies
{
    public class ApiClient(HttpClient httpClient)
    {
        public async Task<Result<UserDto>> AuthenticateUserAsync(AuthenticateDto request)
        {
            var response = await httpClient.PostAsJsonAsync<AuthenticateDto>("/api/user/authenticate", request);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Result<UserDto>>(content)!;
            return result;
        }
        public async Task<Result<UserDto>> CreateUserAsync(UserDto user)
        {
            var response = await httpClient.PostAsJsonAsync<UserDto>("/api/users", user);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Result<UserDto>>(content)!;
            return result;
        }

        public async Task<Result<Guid>> GetCheckUserAsync(UserDto user)
        {
            var response = await httpClient.PostAsJsonAsync<UserDto>("/api/user/check-user", user);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Result<Guid>>(content)!;
            return result;
        }

        public async Task<Result<UserDto>> GetUserAsync(Guid id)
        {

           var response = await httpClient.GetAsync($"/api/user/{id}");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Result<UserDto>>(content)!;
            return result;
        }

        public async Task<Result<List<VenueDto>>> GetVenuesAsync()
        {
            var response = await httpClient.GetAsync("/api/venues");
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Result<List<VenueDto>>>(content)!;
            return result;
        }
    }
}
