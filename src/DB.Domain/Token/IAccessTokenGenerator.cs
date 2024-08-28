namespace DB.Domain.Token;

public interface IAccessTokenGenerator
{
    public string Generate(Guid userIdentifier);

}