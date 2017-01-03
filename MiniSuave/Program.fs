﻿
open Suave.Http
open Suave.Console
open Suave.Successful
open Suave.Combinators
open Suave.Filters

[<EntryPoint>]
let main argv = 
    let request = { Route = ""; Type = Suave.Http.GET }
    let response= { Content = ""; StatusCode = 200 }
    let context = { Request = request; Response = response }
    executeInLoop context (GET >=> Path "/hello" >=> OK "HELLO")
    System.Console.ReadLine() |> ignore
    0
