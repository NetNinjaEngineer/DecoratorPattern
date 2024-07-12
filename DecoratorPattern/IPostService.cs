namespace DecoratorPattern;

// component ==> interface / abstract class
public interface IPostService
{
    Task<Post?> GetPost(int postId);
}
