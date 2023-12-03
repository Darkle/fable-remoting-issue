open System
open Microsoft.AspNetCore.Builder
open Fable.Remoting.Server
open Fable.Remoting.AspNetCore
open Microsoft.AspNetCore.Hosting
open SharedTypes

let postTimestamp = "2023-12-03T11:49:41"

let getPostTimestamp () = async { return postTimestamp }
let getPostTimestamp_Result () = async { return Ok(postTimestamp) }

let apiPostsEndpoints: Api =
    { getPostTimestamp = getPostTimestamp
      getPostTimestamp_Result = getPostTimestamp_Result }

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
