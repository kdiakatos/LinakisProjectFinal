using Dapper;
using LinakisProject.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace LinakisProject.Repository.Repositories
{
    public class PageRepository : IPageRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public PageRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection");
        }

        public async Task<string> GetById(int id)
        {
            var query = "SELECT Title FROM PAGE WHERE Id = @id";
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<string>(query, new { id = id });
            }
        }
    }
}
