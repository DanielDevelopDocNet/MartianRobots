using Microsoft.Extensions.DependencyInjection;
using MartianRobots;
using System.Drawing;

var collection = new ServiceCollection();
collection.AddScoped<IAppConsole, AppConsole>();

IServiceProvider serviceProvider = collection.BuildServiceProvider();

var app = serviceProvider.GetService<IAppConsole>();

app.Execute();

app.Exit();
