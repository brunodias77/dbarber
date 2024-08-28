using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Domain.Entities;

[Table("Users")]
public class User : BaseEntity
{
    [Column("FistName")]
    private string FirstName;
    [Column("LastName")]
    private string LastName;
    [Column("Email")]
    private string Email;
    [Column("Password")]
    private string Password;
    [Column("Avatar")]
    private string? Avatar;

    public User(string firstName, string lastName, string email, string password, string? avatar = null)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        Avatar = avatar;
    }

    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }
}