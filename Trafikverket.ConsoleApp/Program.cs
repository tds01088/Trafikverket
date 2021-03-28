using System;
using Figgle;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Trafikverket.Application;
using Trafikverket.Infrastructure;
using Trafikverket.Persistence;
using Microsoft.Extensions.Configuration;
using System.IO;
using MediatR;
using Trafikverket.Application.Features.Camera.CameraService;
using Serilog;
using Trafikverket.Application.Features.Camera.Commands.CreateCamera;
using Trafikverket.Application.Features.Camera.Queries.GetCameraList;
using Trafikverket.Application.Exceptions;
using Newtonsoft.Json;

Console.WriteLine(
     FiggleFonts.Standard.Render("Trafikverket, ConsoleApp .NET 5"));



var configuration = BuildConfig(new ConfigurationBuilder());

Log.Logger = new LoggerConfiguration()
               .ReadFrom.Configuration(configuration)
               .Enrich.FromLogContext()
               .WriteTo.File($"Logs/log-.txt", rollingInterval: RollingInterval.Day)
               //.WriteTo.Console()
               .CreateLogger();

var builder = new HostBuilder()
               .ConfigureServices((hostContext, services) =>
               {
                   services.AddApplicationServices();
                   services.AddInfrastructureServices(configuration);
                   services.AddPersistenceServices(configuration);

               }).UseSerilog()
               .UseConsoleLifetime();

var host = builder.Build();



Log.Information("Application Starting");

try
{

    //Get MediatR by resolver
    var _mediator = ActivatorUtilities.GetServiceOrCreateInstance<IMediator>(host.Services);

    //Get CameraDetail from Trafikverket Service API
    var CameraDtos = await _mediator.Send(new GetCameraDetailServiceQuery() { PayloadName = "GetAllCamera" });
    foreach (var item in CameraDtos)
    {     

        //Create command (save Camera)
      await _mediator.Send(new CreateCameraCommand()
        {
            Active = item.Active,
            ContentType = item.ContentType,
            Name = item.Name,
            Direction = item.Direction
        });
     
    }
    Console.WriteLine($"Antal kameror {CameraDtos.Count}");

    //get CameraList from MemoryDatabase
     var cameraList = await _mediator.Send(new GetCameraListWithDirection90Query());
    Console.WriteLine($"Antal kameror som har ”direction: 90 ” {cameraList.Count}");  
   
}
catch (Exception exception)
{
  var result = string.Empty;
    switch (exception)
    {
        case ValidationException validationException:
            result = JsonConvert.SerializeObject(validationException.ValdationErrors);
            break;
        case Exception ex:
            break;
    }
    if (result == string.Empty)
    {
        result = JsonConvert.SerializeObject(new { error = exception.Message });
    }
    Log.Error(result, "An error occured while starting the application");
}


static IConfiguration BuildConfig(IConfigurationBuilder builder)
{
    
    builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?? "Production"}.json")
            .AddEnvironmentVariables();
    return builder.Build();
}
