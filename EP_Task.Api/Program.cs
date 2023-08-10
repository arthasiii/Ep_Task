using EP_Task.Api.Formater;
using EP_Task.Application.CQRS.AuthenticateComandQuery.Command;
using EP_Task.Infrastructure;
using EP_Task.Infrastructure.Infrastructurecontext;
using EP_Task.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using EP_Task.Application;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionstring = builder.Configuration.GetConnectionString("EPTaskDbcontextConnection") ?? throw new InvalidOperationException("Connection string 'AccountFininaceContextConnection' not found.");
builder.Services.AddDbContext<EPTaskDbcontext>(options =>
{
    options.UseSqlServer(connectionstring);
});
builder.Services.AddOptions();
builder.Services.Configure<Configs>(builder.Configuration.GetSection("Configs"));
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
}); ;
var config = new AutoMapper.MapperConfiguration(cfg =>
{ cfg.AddProfile(new EP_Task.Application.mapping.AutpmaperConfig()); });
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddMvc(options =>
{
options.InputFormatters.Insert(0, new XmlSerializerInputFormatter(options));
    //options.OutputFormatters.Insert(0, new XmlSerializerOutputFormatter());
    options.InputFormatters.Add(new CustomInputFormatter());

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfra();
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(RegisterCommand).Assembly);
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

app.MapControllers();

app.Run();
