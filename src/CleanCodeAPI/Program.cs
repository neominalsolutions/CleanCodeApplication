using Aspect.Core;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CleanCodeAPI.Middlwares;
using Domain;
using Domain.Contracts;
using Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<LogPerformaceAspect>();
//builder.Services.AddScoped<IAccountService, AccountService>();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
{
  builder.RegisterAssemblyModules(typeof(AspectModule).Assembly);
  builder.RegisterAssemblyModules(typeof(DomainModule).Assembly);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();




app.Use(async (context, next) =>
{
  // context.User.IsInRole("Admin");

  Console.WriteLine("Request");
  await next();
  Console.WriteLine("Response");
});

app.UseCustomException();

app.MapControllers();

app.Run();
