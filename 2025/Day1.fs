module AdventOfCode2025.Day1

open System
open Serilog

let log = Log.Logger.ForContext(Serilog.Core.Constants.SourceContextPropertyName, "Day1")

// Set the initial position of the dial
let initialDialPosition = 50

// Parse a line like "L10" or "R5" into an integer movement, where L is negative and R is positive
let parseLine (line: string) : int =
    let sign = if line.[0] = 'L' then -1 else 1
    let number = line.[1..] |> int
    sign * number

// Rotate the dial from the current position by the given movement
let rotateDial (currentPosition: int) (move: int) : int =
    let newPosition = (currentPosition + move) % 100
    if newPosition < 0 then newPosition + 100 else newPosition

let execute (filePath: string) =
    let result =
        // Read all the lines from the file
        System.IO.File.ReadAllLines(filePath)
        // Parse each line into a movement
        |> Seq.map(parseLine)
        // Debug
        |> Seq.map(fun line ->
            log.Debug $" - parsed line: {line}"
            line
            )
        // Rotate the dial starting from the initial position
        |> Seq.scan rotateDial initialDialPosition
        |> Seq.map(fun position ->
            log.Debug $" - got rotated position {position}"
            position
            )
        // Keep only the positions that are at 0
        |> Seq.filter(fun x -> x = 0)
        // Count how many times we hit 0
        |> Seq.length
    log.Debug $"result = {result}"
    ()