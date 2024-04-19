namespace RSAllies.Data.Contracts
{
	public class VenueDto
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;
		public int Capacity { get; set; }
	}
}
