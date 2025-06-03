using minimalApi.Model;

namespace minimalApi.Services
{
	public interface ITodoService
	{
		//
		public Task<IEnumerable<TodoModel>> GetAllAsync();

		public Task CreateTodo(TodoModel todoModel);

		public Task UpdateAsync(TodoModel todoModel);
		public Task<TodoModel> GetByIdAsync(int id);
		public Task<bool> DeleteByIdAsync(int id);
	}
}
