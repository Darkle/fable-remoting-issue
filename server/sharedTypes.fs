module SharedTypes

[<CLIMutable>]
type Post = { timestamp: string }

type ApiPostsEndpoints =
    { findPosts_Paginated: unit -> Async<Post> }
