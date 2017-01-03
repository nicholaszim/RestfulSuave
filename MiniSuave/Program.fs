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
    //    executeInLoop context (GET >=> Path "/hello" >=> OK "HELLO")
    let app = 
        Choose [ GET >=> Path "/hello" >=> OK "Hello GET"
                 POST >=> Path "/hello" >=> OK "Hello POST"
                 Path "/foo" >=> Choose [ GET >=> OK "Foo GET"
                                          POST >=> OK "Foo POST" ] ]
    executeInLoop context app
    System.Console.ReadLine() |> ignore
    0
