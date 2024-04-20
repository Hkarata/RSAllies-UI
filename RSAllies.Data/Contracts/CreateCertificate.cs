namespace RSAllies.Data.Contracts;

public class CreateCertificate
{
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
}