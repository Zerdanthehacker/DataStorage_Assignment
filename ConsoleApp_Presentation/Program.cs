using ConsoleApp_Presentation;
using Data.Contexts;
using Data.Repositories;
using Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

var services = new ServiceCollection()
    .AddDbContext<DataContext>(x => x.UseSqlServer("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Projects\\DataStorage_Assignment\\Data\\Databases\\local_database.mdf; Integrated Security = True; Connect Timeout = 30; Encrypt = True"))
    .AddScoped<CustomerRepository>()
    .AddScoped<ProjectRepository>()
    .AddScoped<CustomerService>()
    .AddScoped<ProjectService>()
    .AddScoped<MenuDialogs>()
    .BuildServiceProvider();

var menuDialogs = services.GetRequiredService<MenuDialogs>();
await menuDialogs.MenuOptions();





