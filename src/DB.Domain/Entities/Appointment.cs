using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Domain.Entities;

[Table("Appointments")]
public class Appointment : BaseEntity
{
    [Column("provider_id")]
    public Guid ProviderId { get; set; }

    [ForeignKey("ProviderId")]
    public virtual User Provider { get; set; }

    [Column("user_id")]
    public Guid UserId { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    [Column("date", TypeName = "timestamp with time zone")]
    public DateTime Date { get; set; }
    
}