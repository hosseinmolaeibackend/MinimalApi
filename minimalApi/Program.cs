using Microsoft.EntityFrameworkCore;
using minimalApi.Configurations;
using minimalApi.AppDb;
using minimalApi.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using minimalApi.Model;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITodoService, TodoService>();


builder.Services.AddAuthorization();

// Add DbContext
builder.Services.AddDbContext<AppDBContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("default")));

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapGroup("/TodoMinimalApi");

app.MapGet("/", () => "Hello from Minimal API!");

app.MapGet("/GetAll", async (ITodoService service) =>
{
	var result = await service.GetAllAsync();
	if (result == null) return Results.BadRequest(result);
	return Results.Ok(result);
});

app.MapPost("/AddTodo", async Task<Results<Ok, BadRequest<string>>> (TodoModel model, ITodoService service) =>
{
	try
	{
		await service.CreateTodo(model);
		return TypedResults.Ok();
	}
	catch (Exception ex)
	{
		return TypedResults.BadRequest(ex.Message);
	}
});

app.MapPut("/UpdateTodo", async Task<Results<Ok, BadRequest<string>>> (TodoModel model, ITodoService service) =>
{
	try
	{
		await service.UpdateAsync(model);
		return TypedResults.Ok();
	}
	catch (Exception ex)
	{
		return TypedResults.BadRequest(ex.Message);
	}

});

app.MapDelete("/DeleteTodo", async Task<Results<Ok, BadRequest<string>>> (int ID, ITodoService service) =>
{
	try
	{
		await service.DeleteByIdAsync(ID);
		return TypedResults.Ok();
	}
	catch (Exception ex)
	{
		return TypedResults.BadRequest(ex.Message);
	}

});

app.MapGet("/GetSingleTodo", async (int Id, ITodoService service) =>
{
	try
	{
		var result = await service.GetByIdAsync(Id);
		return Results.Ok(result);
	}
	catch (Exception ex)
	{
		return TypedResults.BadRequest(ex.Message);
	}

});

app.Run();
