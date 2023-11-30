module SharedTypes

[<CLIMutable>] // this is the issue
type Post = { timestamp: string }

type ApiPostsEndpoints = { getPost: unit -> Async<Post> }
