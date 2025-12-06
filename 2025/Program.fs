// For more information see https://aka.ms/fsharp-console-apps
open Microsoft.Extensions.Configuration
open Serilog
open AdventOfCode2025

let toFullPath (relativePath: string) =
    System.IO.Path.Combine(System.AppContext.BaseDirectory, "..", "..", "..", relativePath)

let configuration =
        ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build()
Log.Logger <- LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger()

Log.Debug "Day 1"
"Resources/Day1.0.txt"
    |> toFullPath
    |> Day1.execute
"Resources/Day1.1.txt"
    |> toFullPath
    |> Day1.execute