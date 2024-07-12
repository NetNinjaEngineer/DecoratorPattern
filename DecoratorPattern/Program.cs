using DecoratorPattern;

IPostService postService = new PostService(new HttpClient());
postService = new PostServiceLoggingDecorator(postService);
postService = new PostServiceCacheDecorator(postService);


try
{
    var post = await postService.GetPost(1);
    Console.WriteLine(post);

    // request the same post second time
    Console.WriteLine("Getting the same post again:");
    post = await postService.GetPost(1);
    Console.WriteLine(post);

}
catch (Exception ex)
{
    System.Console.WriteLine(ex.Message);
}