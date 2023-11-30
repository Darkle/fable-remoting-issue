module clientThing

open Fable.Remoting.DotnetClient
open SharedTypes

let server =
    Remoting.createApi "http://localhost:8088"
    |> Remoting.buildProxy<ApiPostsEndpoints>

[<EntryPoint>]
let main _ =
    async {
        let! res = server.getPost ()
        printfn "%A" res
    }
    |> Async.RunSynchronously

    0
