namespace KpiScope.Web.Register;

public class RegisterRequest
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    public int ComapanyId { get; set; }
}
