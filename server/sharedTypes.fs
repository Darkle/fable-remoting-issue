module SharedTypes

type PostTimestamp = string

type Api =
    { getPostTimestamp: unit -> Async<PostTimestamp>
      getPostTimestamp_Result: unit -> Async<Result<PostTimestamp, exn>> }
