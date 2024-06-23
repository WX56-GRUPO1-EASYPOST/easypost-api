using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace easypost_api.Requests.Domain.Model.Aggregates;

public partial class Request: IEntityWithCreatedUpdatedDate
{
    [Column("createdAt")]
    public DateTimeOffset? CreatedDate { get; set; }
    
    [Column("updatedAt")]
    public DateTimeOffset? UpdatedDate { get; set; }
}