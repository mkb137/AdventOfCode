// For more information see https://aka.ms/fsharp-console-apps
open Microsoft.Extensions.Configuration
open Serilog

let configuration =
        ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build()
Log.Logger <- LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger()

Log.Debug "Start"