using Newtonsoft.Json;
using RSAllies.Data.Contracts;
using RSAllies.Data.HelperTypes;

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

        public async Task<Result<List<SessionDto>>?> GetVenueSessionsAsync(string id)
        {
            var response = await httpClient.GetAsync($"api/venue/{id}/sessions");
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<Result<List<SessionDto>>>(content)!;
                return result;
            }
            else
            {
                return null;
            }

        }

        public async Task<Result<List<FilteredSessionDto>>?> GetFilteredSessionsAsync(string region, DateTime date)
        {
            var dateInIso8601Format = date.ToString("yyyy-MM-ddTHH:mm:ssZ");
            var response = await httpClient.GetAsync($"/api/sessions/filter/region/{region}/date/{dateInIso8601Format}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) return null;
            var result = JsonConvert.DeserializeObject<Result<List<FilteredSessionDto>>>(content)!;
            if (result.IsFailure) return null;
            return result;

        }

        public async Task<Result<BookingDto>?> GetCurrentUserBooking(Guid id)
        {
            var response = await httpClient.GetAsync($"/api/bookings/user/{id}/current-booking");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) return null;
            var result = JsonConvert.DeserializeObject<Result<BookingDto>>(content)!;
            return result;

        }

        public async Task<Result<List<QuestionDto>>?> GetQuestions()
        {
            var response = await httpClient.GetAsync("/api/questions");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) return null;
            var result = JsonConvert.DeserializeObject<Result<List<QuestionDto>>>(content);
            return result;
        }

        public async Task<Result<List<QuestionDto>>?> GetSwahiliQuestions()
        {
            var response = await httpClient.GetAsync("/api/questions/swahili");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) return null;
            var result = JsonConvert.DeserializeObject<Result<List<QuestionDto>>>(content);
            return result;
        }

    }
}
