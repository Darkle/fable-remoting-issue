module clientThing

open Fable.Remoting.DotnetClient
open SharedTypes

let server = Remoting.createApi "http://localhost:8088" |> Remoting.buildProxy<Api>

[<EntryPoint>]
let main _ =
    async {
        let! res = server.getPostTimestamp ()

        printfn "getPost: %A" res

        let! res = server.getPostTimestamp_Result ()

        match res with
        | Ok r -> printfn "getPost_Result: %A" r
        | Error e -> printfn "error: %A" e

    }
    |> Async.RunSynchronously

    0
