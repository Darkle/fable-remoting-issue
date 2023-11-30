open System
open Microsoft.AspNetCore.Builder
open Fable.Remoting.Server
open Fable.Remoting.AspNetCore
open Microsoft.AspNetCore.Hosting
open SharedTypes

let posts =
    [ { timestamp = "2023-12-01T09:21:01" }
      { timestamp = "2023-12-01T09:20:01" }
      { timestamp = "2023-12-01T09:20:01" } ]


let findPosts_Paginated () = async { return { timestamp = "2023-12-01T09:21:01" } }

let apiPostsEndpoints: ApiPostsEndpoints =
    { findPosts_Paginated = findPosts_Paginated }

let webApp = Remoting.createApi () |> Remoting.fromValue apiPostsEndpoints

let configureApp (app: IApplicationBuilder) = app.UseRemoting(webApp)

[<EntryPoint>]
let main _ =
    WebHostBuilder()
        .UseKestrel()
        .Configure(Action<IApplicationBuilder> configureApp)
        .UseUrls("http://localhost:8088")
        .Build()
        .Run()

    0
