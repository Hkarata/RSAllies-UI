using Mapster;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RSAllies.Authentication;
using RSAllies.Contracts.Contracts;
using RSAllies.Models.English;
using RSAllies.Models.Swahili;

namespace RSAllies.Pages;

public class LoginModel(ApiClient apiClient, AuthenticationStateProvider authenticationStateProvider) : PageModel
{
	[BindProperty]
	public Login? Login { get; set; }

	[BindProperty]
	public SLogin? SLogin { get; set; }

	public string StatusMessage { get; set; } = string.Empty;

	public void OnGet()
	{

	}

	private async Task AuthenticationHandler(UserDto data)
	{
		var customAuthStateProvider = (CustomAuthenticationStateProvider)authenticationStateProvider;
		await customAuthStateProvider.UpdateAuthenticationState(data);
	}
	public async Task<IActionResult> OnPostAsync()
	{
		var submittedForm = Request.Form["submittedForm"]; // Access form name
		var authDto = submittedForm == "English" ? Login.Adapt<AuthenticateDto>() : SLogin.Adapt<AuthenticateDto>();

		var result = await apiClient.AuthenticateUserAsync(authDto);
		if (result.IsSuccess)
		{
			await AuthenticationHandler(result.Value);
		}
		else
		{
			StatusMessage = "Error! User Authentication with the provided credentials has failed";
			return Page();
		}

		return RedirectToPage("./Home");
	}
}