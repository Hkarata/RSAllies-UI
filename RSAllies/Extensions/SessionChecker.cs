using RSAllies.Contracts;
using Newtonsoft.Json;

namespace RSAllies.Extensions;

public class SessionChecker(IHttpContextAccessor httpContextAccessor)
{
    public bool Check()
    {
        var session = httpContextAccessor.HttpContext?.Session.GetString("UserSession");
        return !string.IsNullOrEmpty(session);
    }

    public UserDto? GetUserData()
    {
        var session = httpContextAccessor.HttpContext?.Session.GetString("UserSession");
        var data = JsonConvert.DeserializeObject<UserDto>(session!);
        return data;
    }
}