using Marten;
using Microsoft.AspNetCore.Mvc;
using TodosApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("todos") ??
    throw new Exception("Can't start, need a connection string");

builder.Services.AddMarten(options =>
{
    // IDocumentSession
    options.Connection(connectionString);
}).UseLightweightSessions();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// GET /status
app.MapGet("/status", () =>
{
    return Results.Ok();
});

// GET /todos
app.MapPost("/todos", async ([FromBody] TodoCreateRequest request,
    [FromServices] IDocumentSession session) =>
{
    // look at the content they sent, and validate it.
    // if it's not "valid", send them a 400 response.
    // if it is valid
    //  - Assign an ID to it.
    //  - Save it somewhere (Database?)
    //  - Send it back to them.
    //Fake it - 
    var response = new TodoCreateResponse
    {
        Id = Guid.NewGuid(),
        Description = request.Description,
        Status = TodoStatus.Incomplete
    };
    session.Store(response);
    await session.SaveChangesAsync(); // actually write it to the database.
    return Results.Ok(response);
});

app.MapGet("/todos", async ([FromServices] IDocumentSession session) =>
{
    var todoList = await session.Query<TodoCreateResponse>().ToListAsync();
    return Results.Ok(todoList);
});

app.Run();

public partial class Program { }