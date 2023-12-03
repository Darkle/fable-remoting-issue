module SharedTypes

type Post = { timestamp: string }

type Api =
    { getPost: unit -> Async<Post>
      getPost_Result: unit -> Async<Result<Post, exn>> }
