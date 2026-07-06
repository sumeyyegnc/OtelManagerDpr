using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace OtelManagerDpr
{
    public static class Context
    {
        private static readonly string baglanti =
            "Server=(localdb)\\MSSQLLocalDB;Database=OtelManagerDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static List<T> Listeleme<T>(string spName, DynamicParameters param = null)
        {
            using IDbConnection db = new SqlConnection(baglanti);
            return db.Query<T>(spName, param, commandType: CommandType.StoredProcedure).ToList();
        }

        public static int ExecuteReturn(string spName, DynamicParameters param = null)
        {
            using IDbConnection db = new SqlConnection(baglanti);
            return db.Execute(spName, param, commandType: CommandType.StoredProcedure);
        }
    }
}