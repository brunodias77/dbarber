namespace DB.Application.Communications.Requests.Users
{
    public record CreateUserRequestJson(
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string? Avatar
    )
    {

    }
}