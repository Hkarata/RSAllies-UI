﻿namespace RSAllies.Contracts
{
	public record UserDto
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string? Email { get; set; } = string.Empty;
		public string Phone { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;
	}
}
