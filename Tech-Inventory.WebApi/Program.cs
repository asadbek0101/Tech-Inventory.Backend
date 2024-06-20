using Tech_Inventory.Application;
using Tech_Inventory.Persistence;
using Tech_Inventory.WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllersWithViews();
builder.Services.ConfigureWebApi(builder.Configuration);
builder.Services.ConfigureApplication(builder.Configuration);
builder.Services.ConfigurePersistence(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors("AllowAll");
app.Run();
