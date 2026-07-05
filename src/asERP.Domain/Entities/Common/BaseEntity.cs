using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace asERP.Domain.Entities.Common;

// public abstract class BaseEntity
public class BaseEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DateModified { get; set; } = DateTime.UtcNow;

    public Guid? TenantId { get; set; }
}

public class BaseEntityWithoutTenant
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime DateModified { get; set; } = DateTime.UtcNow;
}

public interface IBaseEntity
{
    Guid Id { get; set; }
    DateTime DateCreated { get; set; }
    DateTime DateModified { get; set; }
    Guid? TenantId { get; set; }
}

public interface IBaseEntityWithoutTenant
{
    Guid Id { get; set; }
    DateTime DateCreated { get; set; }
    DateTime DateModified { get; set; }
}

/// <summary>
/// Marks an aggregate that carries an application-managed optimistic-concurrency token.
/// The token is refreshed on every insert/update in <c>ApplicationDbContext.SaveChangesAsync</c>
/// and configured with <c>IsConcurrencyToken()</c>. A GUID is used (not a DB rowversion) so the
/// same shared configuration works across all providers (MSSQL, PostgreSQL, SQLite).
/// </summary>
public interface IConcurrencyStamped
{
    Guid ConcurrencyToken { get; set; }
}
