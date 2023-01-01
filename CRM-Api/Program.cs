using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CompanyDb>(opt => opt.UseInMemoryDatabase("TodoList"));
