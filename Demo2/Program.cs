using Demo2.Interfaces;
using Demo2.Repository;
using Demo2.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Add DI
AddDI(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void AddDI(IServiceCollection services)
{
    //Pokemon
    services.AddScoped<PokemonRepository>();
    services.AddScoped<IPokemonService, PokemonService>();
    //Category
    services.AddScoped<CategoryRepository>();
    services.AddScoped<ICategoryService, CategoryService>();
    //Region
    services.AddScoped<RegionRepository>();
    services.AddScoped<IRegionService, RegionService>();
    //Owner
    services.AddScoped<OwnerRepository>();
    services.AddScoped<IOwnerService, OwnerService>();

    services.AddAutoMapper(typeof(Program).Assembly);
}