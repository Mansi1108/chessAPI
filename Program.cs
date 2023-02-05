using Autofac;
using Autofac.Extensions.DependencyInjection;
using chessAPI;
using chessAPI.business.interfaces;
using chessAPI.models.player;
using chessAPI.models.game;
using chessAPI.models.team;
using Microsoft.AspNetCore.Authorization;
using Serilog;
using Serilog.Events;

//Serilog logger (https://github.com/serilog/serilog-aspnetcore)
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("chessAPI starting");
    var builder = WebApplication.CreateBuilder(args);

    var connectionStrings = new connectionStrings();
    builder.Services.AddOptions();
    builder.Services.Configure<connectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));
    builder.Configuration.GetSection("ConnectionStrings").Bind(connectionStrings);

    // Two-stage initialization (https://github.com/serilog/serilog-aspnetcore)
    builder.Host.UseSerilog((context, services, configuration) => configuration.ReadFrom
             .Configuration(context.Configuration)
             .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning).ReadFrom
             .Services(services).Enrich
             .FromLogContext().WriteTo
             .Console());

    // Autofac como inyección de dependencias
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new chessAPI.dependencyInjection<int, int>()));
    var app = builder.Build();
    app.UseSerilogRequestLogging();
    app.UseMiddleware(typeof(chessAPI.customMiddleware<int>));
    app.MapGet("/", () =>
    {
        return "hola mundo";
    });

    //ENDPOINTS PLAYER

    app.MapPost("/player", 
    [AllowAnonymous] async(IPlayerBusiness<int> bs, clsNewPlayer newPlayer) => Results.Ok(await bs.addPlayer(newPlayer)));

    app.MapGet("/getPlayers",
    [AllowAnonymous] async(IPlayerBusiness<int> bs) => Results.Ok(await bs.getPlayers()));

    // app.MapPut("/putPlayer",
    // [AllowAnonymous] async(IPlayerBusiness<int> bs, clsPutPlayer updatedPlayer) => Results.Ok(await bs.putPlayer(updatedPlayer)));

    //EndPoint GAME
    app.MapPost("/newgame",
    [AllowAnonymous] async(IGameBusiness<int> bs, clsNewGame newGame) => Results.Ok(await bs.addGame(newGame)));
    

    app.MapGet("/getgames",
    [AllowAnonymous] async(IGameBusiness<int> bs) => Results.Ok(await bs.getGames()));

    // app.MapPut("/putgame",
    // [AllowAnonymous] async(IGameBusiness<int> bs, clsPutGame updatedGame) => Results.Ok(await bs.putGame(updatedGame)));

    //ENDPOINTS TEAM
    app.MapPost("/newteam",
    [AllowAnonymous] async(ITeamBusiness<int> bs, clsNewTeam newTeam) => Results.Ok(await bs.addTeam(newTeam)));
    

    app.MapGet("/getteams",
    [AllowAnonymous] async(ITeamBusiness<int> bs) => Results.Ok(await bs.getTeams()));

    // app.MapPut("/putteam",
    // [AllowAnonymous] async(ITeamBusiness<int> bs, clsPutTeam updatedTeam) => Results.Ok(await bs.putTeam(updatedTeam)));

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "chessAPI terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
