using System.Runtime.CompilerServices;
using asERP.Application.Contracts.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace asERP.Persistence.DatabaseContext;

/// <summary>
/// Model cache key that includes the <see cref="ICredentialEncryptor"/> instance of the context.
/// <para>
/// EF caches one model per DbContext CLR type, and <c>ApplicationDbContext.OnModelCreating</c> bakes the
/// injected encryptor into the value converters of every credential column. With the default cache key
/// the first context created in the process therefore decides how every later context encrypts: a context
/// built without an encryptor (identity-function fallback) hands its cleartext converters to contexts that
/// do have the DataProtection encryptor, and credentials silently land in the database unencrypted.
/// Keying the cache on the encryptor identity keeps those models apart.
/// </para>
/// <para>
/// This assumes <see cref="ICredentialEncryptor"/> is registered as a singleton - one model is built per
/// distinct encryptor instance.
/// </para>
/// </summary>
public sealed class CredentialEncryptorModelCacheKeyFactory : IModelCacheKeyFactory
{
    public object Create(DbContext context, bool designTime)
        => new CredentialEncryptorModelCacheKey(context, designTime);

    private sealed class CredentialEncryptorModelCacheKey
    {
        private readonly Type _contextType;
        private readonly bool _designTime;
        private readonly ICredentialEncryptor? _encryptor;

        public CredentialEncryptorModelCacheKey(DbContext context, bool designTime)
        {
            _contextType = context.GetType();
            _designTime = designTime;
            _encryptor = (context as ApplicationDbContext)?.CredentialEncryptor;
        }

        public override bool Equals(object? obj)
            => obj is CredentialEncryptorModelCacheKey other
               && _contextType == other._contextType
               && _designTime == other._designTime
               && ReferenceEquals(_encryptor, other._encryptor);

        public override int GetHashCode()
            => HashCode.Combine(_contextType, _designTime, RuntimeHelpers.GetHashCode(_encryptor));
    }
}
