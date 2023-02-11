using Microsoft.EntityFrameworkCore;
using Param_.Net_Practicum.Infrastructure.Persistence;
using Param_.Net_Practicum.Infrastructure.Persistence.Context;
using Param_.Net_Practicum.Infrastructure.Persistence.Extensions;
using Param_.Net_Practicum.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add<RequestValidationFilter>();
}).ConfigureApiBehaviorOptions(opt => opt.SuppressModelStateInvalidFilter = true); ;

builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseInMemoryDatabase("CommerceDB"));
builder.Services.AddTransient<LogginMiddware>();
builder.Services.AddTransient<GlobalExceptionMiddleware>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication("Auth");
builder.Services.AddServices();
builder.Services.AddLogging(opt =>
{
    opt.AddConsole();
    opt.AddDebug();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.GenerateProductData(5, 50);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<LogginMiddware>();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseMiddleware<GlobalExceptionMiddleware>();
app.Run();
