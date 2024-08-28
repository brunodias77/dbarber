namespace DB.Domain.Token;

public interface IAccessTokenValidator
{
    public Guid ValidateAndGetUserIdentifier(string token);

}