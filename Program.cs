using MHR.API.ApimAutomation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Configuration;
using System.Reflection;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
//builder.Services.AddDbContext<>
var constr = builder.Configuration.GetValue<string>("ConnectionStrings:CustomerContext","");
builder.Services.AddControllers();
builder.Services.AddDbContext<CustomerDbContext>(options => options.UseSqlServer(constr));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen
    
    (
        c =>
        {
            // Set Title and version from config
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Customer API", Version = "1.0", Description = "Use these APIs to get the Customer, their contact and address. " });
            // Set the comments path for the Swagger JSON and UI.
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            // pick comments from classes, include controller comments: another tip from StackOverflow
            c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            // enable the annotations on Controller classes [SwaggerTag]
            c.EnableAnnotations();
            // to allow for a header parameter
            c.OperationFilter<SwaggerExtensionFilter>();
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
