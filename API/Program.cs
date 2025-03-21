
using Microsoft.EntityFrameworkCore;
using Persistence;
using API.Extensions;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.addApplicationServices(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
/*builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>( 
    opt => 
    {opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
    );

 builder.Services.AddCors(opt => {
    opt.AddPolicy("CorsPolicy", policy =>{

        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
    });
 }) ;

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(List.Handler).Assembly));
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);*/ // all this goes to extension methods in extension folder static method.
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try{

    var context = services.GetRequiredService<DataContext>();
   await context.Database.MigrateAsync();
   await Seed.SeedData(context);
}
catch (Exception ex)
{
var logger = services.GetRequiredService<ILogger<Program>>();
logger.LogError(ex.Message , "An error occured during migration");

}


app.Run();
