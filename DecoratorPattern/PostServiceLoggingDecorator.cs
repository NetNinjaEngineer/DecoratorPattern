using System.Diagnostics;

namespace DecoratorPattern;

// concreate decorator
public class PostServiceLoggingDecorator : PostServiceDecorator
{
    public PostServiceLoggingDecorator(IPostService postService) : base(postService)
    {
    }

    public override async Task<Post?> GetPost(int postId)
    {
        Console.WriteLine($"Calling the API to get the post with ID: {postId}");
        var stopwatch = Stopwatch.StartNew();

        try
        {
            var post = await _postService.GetPost(postId);
            Console.WriteLine($"It took {stopwatch.ElapsedMilliseconds} ms to call the API");
            return post;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"GetPostAsync threw exception: {ex.Message}");
            throw;
        }
        finally
        {
            stopwatch.Stop();
        }
    }
}
