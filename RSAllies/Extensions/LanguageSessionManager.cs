namespace RSAllies.Extensions;

public class LanguageSessionManager(IHttpContextAccessor httpContextAccessor)
{
	public bool IsEnglish
	{
		get
		{
			var language = httpContextAccessor.HttpContext?.Session.GetString("Language");
			return language == "True";
		}
		set
		{
			var language = value ? "True" : "False";
			httpContextAccessor.HttpContext?.Session.SetString("Language", language);
		}
	}
}