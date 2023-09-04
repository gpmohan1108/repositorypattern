using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using repositorypattern;
using repositorypattern.Model;
using repositorypattern.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container//.
string con = builder.Configuration.GetConnectionString("default").ToString();
builder.Services.AddDbContext<dBContext>(options => options.UseSqlServer(con));
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(AutoMapperprofile));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton<IProductRepository,InMemoryProductRepository>();

//builder.Services.AddTransient<CustomMiddleware>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());



//Call ConfigureContainer on the Host sub property 
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacModule());
});


var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<CustomMiddleware>();
app.MapControllers();

app.Run();
