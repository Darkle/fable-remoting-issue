module clientThing

open Fable.Remoting.DotnetClient
open SharedTypes

let server = Remoting.createApi "http://localhost:8088" |> Remoting.buildProxy<Api>

[<EntryPoint>]
let main _ =
    async {
        let! res = server.getPost ()

        printfn "getPost: %A" res

        let! res = server.getPost_Result ()

        printfn "getPost_Result: %A" res
    }
    |> Async.RunSynchronously

    0
