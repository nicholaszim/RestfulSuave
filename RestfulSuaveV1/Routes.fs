module Routes

open Suave
open Suave.Filters
open Suave.Successful
open Suave.Operators

let routes = 
        let default_route = path "/" >=> OK "Welcome"
        let get_home = path "/home" >=> OK "hello from get home"
        let get_account = path "/account" >=> OK "hello from get account"
        choose 
            [ 
              GET >=> choose
                [ 
                    default_route
                    get_home
                    get_account
                ]
              POST >=> choose
                [
                    path "/home" >=> OK "Hello post to home"
                    path "/about" >=> OK "Hello post to about"
                ]
            ]