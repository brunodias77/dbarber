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
    private string password;
    [Column("Avatar")]
    private string? avatar;
}