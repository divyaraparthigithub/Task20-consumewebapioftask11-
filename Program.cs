using Microsoft.EntityFrameworkCore;
using Task20_consumewebapioftask11_.Models;
using Task20_consumewebapioftask11_.ServiceLayer;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using log4net.Config;
using log4net;
using Moq;
using Task20_consumewebapioftask11_.Interfaces;
using Task20_consumewebapioftask11_.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionstring")));
builder.Services.AddTransient<ICustomerService,CustomerService>();
builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IGenderRepository,GenderRepository>();
builder.Services.AddScoped<IUnitofworkRepository, UnitofWork>();
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options => { options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
ConfigureLogging();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
void ConfigureLogging()
{
    var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
    XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
}
