module SharedTypes

type Post = { timestamp: string }

type Api =
    { getPost_Result: unit -> Async<Result<Post, exn>>
      getPost: unit -> Async<Post> }
