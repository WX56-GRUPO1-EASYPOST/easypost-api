using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace easypost_api.Profiles.Domain.Model.Aggregates;

public partial class Profile : IEntityWithCreatedUpdatedDate
{
    [Column("createdAt")]
    public DateTimeOffset? CreatedDate { get; set; }
    
    [Column("updatedAt")]
    public DateTimeOffset? UpdatedDate { get; set; }
}