namespace DecoratorPattern;

// decorator
public abstract class PostServiceDecorator : IPostService
{

    protected readonly IPostService _postService;

    protected PostServiceDecorator(IPostService postService)
    {
        _postService = postService;
    }

    public abstract Task<Post?> GetPost(int postId);
}
