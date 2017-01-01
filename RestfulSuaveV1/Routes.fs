module Routes

open Suave
open Suave.Filters
open Suave.Successful
open Suave.Operators

let routes = 
        let default_route = path "/" >=> OK "Welcome"
        let get_home = path "/home" >=> OK "hello from get home"
        let get_account = path "/account" >=> OK "hello from get account"
        let post_home = path "/home" >=> OK "Hello post to home"
        let post_about = path "/about" >=> OK "Hello post to about"

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
                     post_home
                     post_about
                ]
            ]