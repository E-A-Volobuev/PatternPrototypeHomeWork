using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PatternPrototypeHomeWork;
using ServicesLayer.Services.Abstractions;
using ServicesLayer.Services.Implementations;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Start>();
builder.Services.AddScoped<IPersonBynaryCloneService, PersonBynaryCloneService>();

using IHost host = builder.Build();

await host.RunAsync();

