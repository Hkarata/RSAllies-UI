using Newtonsoft.Json;
using RSAllies.Contracts;
using RSAllies.HelperTypes;

namespace RSAllies
{
    public class ApiClient(HttpClient httpClient)
    {
        public async Task<Result<UserDto>> CreateUserAsync(UserDto user)
        {
            var response = await httpClient.PostAsJsonAsync<UserDto>("/api/users", user);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Result<UserDto> result = JsonConvert.DeserializeObject<Result<UserDto>>(content)!;
                return result;
            }
            else
            {
                // Handle error
                return null;
            }
        }

        public async Task<Result<UserDto>> GetCheckUserAsync(UserDto user)
        {
            var response = await httpClient.PostAsJsonAsync<UserDto>("/api/user/check-user", user);
            var content = await response.Content.ReadAsStringAsync();
            Result<UserDto> result = JsonConvert.DeserializeObject<Result<UserDto>>(content)!;
            return result;
        }
    }
}
