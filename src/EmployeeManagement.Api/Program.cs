using AutoMapper;
using EmployeeManagement.Api.Requests;
using EmployeeManagement.Api.Requests.AddEmployee;
using EmployeeManagement.Api.Requests.EditEmployee;
using EmployeeManagement.Api.Requests.GetEmployees;
using EmployeeManagement.Domain;
using EmployeeManagement.Domain.Factories;
using EmployeeManagement.Domain.Services;
using EmployeeManagemet.Infrastructure;
using MediatR;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Auto Mapper Configurations
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new EmployeeDtoAutoMapperConfiguration());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IRegistrationNumberFactory, RegistrationNumberFactory>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<IRequestHandler<AddEmployeeRequest, Guid>, AddEmployeeRequestHandler>();
builder.Services.AddScoped<IRequestHandler<EditEmployeeRequest, Guid>, EditEmployeeRequestHandler>();
builder.Services.AddScoped<IRequestHandler<GetEmployeesRequest, List<EmployeeResponse>>, GetEmployeeRequestHandler>();

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
