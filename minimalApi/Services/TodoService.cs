using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using minimalApi.AppDb;
using minimalApi.Model;

namespace minimalApi.Services
{
	public class TodoService(AppDBContext db) : ITodoService
	{
		public async Task CreateTodo(TodoModel todoModel)
		{
			using var conection = new SqlConnection(db.Database.GetConnectionString());
			var query = """
				Insert Into todoModels (Description,IsComplete)
				Values (@Description,@IsComplete)
				""";
			await conection.ExecuteAsync(query, new { Description = todoModel.Description, IsComplete = todoModel.IsComplete });
		}

		public async Task<bool> DeleteByIdAsync(int id)
		{
			using var conection = new SqlConnection(db.Database.GetConnectionString());
			var query = $"""
				Delete todoModels
				Where Id={id}
				""";
			var affectedRow = await conection.ExecuteAsync(query);

			if (affectedRow == 0) return false;

			return true;
		}

		public async Task<IEnumerable<TodoModel>> GetAllAsync()
		{
			using var conection = new SqlConnection(db.Database.GetConnectionString());
			var query = """
				Select * From todoModels
				""";
			return await conection.QueryAsync<TodoModel>(query);
		}

		public async Task<TodoModel> GetByIdAsync(int id)
		{
			using var conection = new SqlConnection(db.Database.GetConnectionString());
			var query = $"""
				Select * from todoModels
				Where Id={id}
				""";
			var affectedRow = await conection.QueryFirstOrDefaultAsync<TodoModel>(query);

			return affectedRow is not null ? affectedRow : throw new BadHttpRequestException("Failure occurred.");
		}

		public async Task UpdateAsync(TodoModel todoModel)
		{
			using var conection = new SqlConnection(db.Database.GetConnectionString());
			var query = """
				Update todoModels 
				Set Description=@Description ,IsComplete=@IsComplete
				Where Id=@Id
				""";
			var affectedRow = await conection.ExecuteAsync(query, todoModel);
			if (affectedRow == 0)
				throw new BadHttpRequestException("todo invalid");
		}
	}
}
