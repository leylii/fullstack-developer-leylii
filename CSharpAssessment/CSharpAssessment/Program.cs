using CSharpAssessment.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Do not add services here, instead add them in the AddTaskServices method
builder.Services.AddTaskServices();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();