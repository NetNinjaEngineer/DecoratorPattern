namespace DecoratorPattern;

public class PostServiceCacheDecorator : PostServiceDecorator
{

    private static Dictionary<int, Post>? _cache;

    public PostServiceCacheDecorator(IPostService postService) : base(postService)
    {
        _cache = new Dictionary<int, Post>();
    }

    public override async Task<Post?> GetPost(int postId)
    {
        // get post from the cache if it exists..

        if (_cache!.TryGetValue(postId, out var post))
        {
            Console.WriteLine($"Getting the post with id {postId} from the cache");
            return post;
        }
        else
        {
            // if the post does not exists in the cache we will hit the api endpoint to fetch
            // the post and store the post into the cache to be cached for other requests again to the same post

            post = await _postService.GetPost(postId);
            if (post is not null)
            {
                // save post in the cache
                _cache[postId] = post;
            }

            return post;

        }

    }
}