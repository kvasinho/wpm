using Microsoft.Extensions.DependencyInjection;

using Spectre.Console.Cli;
using WPM.Commands;
using WPM.TextGenerator;
using WPM.Util;


var services = new ServiceCollection();

services.AddScoped<ITextGeneratorService, TextGeneratorService>();
//services.AddSingleton<ICsvDisplayService, CsvDisplayService>();
//services.AddSingleton<ITableGeneratorService, TableGeneratorService>();

var registrar = new TypeRegistrar(services);



var app = new CommandApp(registrar); 

app.Configure(config =>
{

    config.AddCommand<ClassicCommand>("classic")
        .WithDescription("Start a new classic mode game.");
    /*
    config.AddCommand<DimensionsCommand>("dimensions")
        .WithDescription("Shows number of rows, columns, as well as file size.");

    config.AddCommand<ConvertCommand>("convert")
        .WithDescription("Converts a csv to json");
        */
});

return app.Run(args);