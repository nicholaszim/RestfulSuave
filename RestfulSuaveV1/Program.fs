open Suave
open Suave.Filters
open Suave.Successful
open Suave.Operators
open System.Net
open Routes

[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    printfn "Starting server..."
    let app = routes
    let config = { defaultConfig with bindings = [ HttpBinding.mk HTTP IPAddress.Loopback 9000us ] }
    startWebServer config app
    0
