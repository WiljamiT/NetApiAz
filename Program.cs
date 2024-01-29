using Microsoft.EntityFrameworkCore;
using WebApiReact;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactAppAndAzure",
        builder => builder
            .WithOrigins("http://localhost:3000", "https://wt-app.azurewebsites.net")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowReactAppAndAzure");

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Data}/{action=GetCustomers}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Data}/{action=GetCustomers}/{id?}");

app.Run();
