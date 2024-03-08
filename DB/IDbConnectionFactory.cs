using System.Data;

namespace IverMiniApi.DB

{
    public interface IDbConnectionFactory
    {
        Task<IDbConnection> CreateConnectionAsync();
    }
}
