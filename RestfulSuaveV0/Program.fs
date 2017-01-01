open Suave
open Suave.Filters
open Suave.Successful
open Suave.Operators
open System.Net

[<EntryPoint>]
let main argv = 
    let app = 
        choose 
            [ GET >=> choose
                [ path "/home" >=> OK "hello from home"
                  path "/account" >=> OK "hello from get account" ]
              POST >=> choose
                [
                    path "/home" >=> OK "Hello post to home"
                    path "/about" >=> OK "Hello post to about"
                ]
            ]
    let config = { defaultConfig with 
                    bindings =
                                [ HttpBinding.mk HTTP IPAddress.Loopback 9000us] }
    startWebServer config app
    0