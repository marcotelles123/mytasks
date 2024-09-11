using MyTasks.Domain.VO;
using Npgsql;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace MyTasks.Infra
{
    public class MyTasksRepositoryPostgres : IMyTasksRepository
    {
        private readonly string _connectionString;

        public MyTasksRepositoryPostgres(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("PostgresConnectionString");
        }

        public void CreateMyTask(MyTaskVO myTaskVO)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var sql = "INSERT INTO MyTasks (Title, Description) VALUES (@Title, @Description)";
                connection.Execute(sql, myTaskVO);
            }
        }

        public IEnumerable<MyTaskVO> GetAllMyTasks()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM MyTasks";
                return connection.Query<MyTaskVO>(sql);
            }
        }

        public MyTaskVO GetById(long id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM MyTasks WHERE Id = @Id";
                return connection.Query<MyTaskVO>(sql, id).FirstOrDefault();
            }
        }

        public void DeleteMyTask(long id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var sql = "DELETE FROM MyTasks WHERE Id = @Id";
                connection.Execute(sql, new { Id = id });
            }
        }

        public MyTaskVO UpdateMyTask(MyTaskVO myTaskVO)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                const string sql = @"UPDATE MyTasks SET title = @Title, description = @Description WHERE id = @Id RETURNING *;";
                var multi = connection.QueryMultiple(sql, new { myTaskVO.Id, myTaskVO.Title, myTaskVO.Description });
                return multi.ReadSingle<MyTaskVO>();
            }
        }

        public MyTaskVO MarkAsDone(long id, bool done)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                const string sql = @"UPDATE MyTasks SET done = @done WHERE id = @Id RETURNING *;";
                var multi = connection.QueryMultiple(sql, new { done });
                return multi.ReadSingle<MyTaskVO>();
            }
        }
    }
}
