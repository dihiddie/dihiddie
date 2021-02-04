namespace dihiddie.Utils.GoogleBlogpostsLoader
{
    using System.IO;
    using System.Text;

    using dihiddie.DAL.Post.Core.Models;
    using dihiddie.DAL.Post.Core.Repositories;
    using dihiddie.DAL.Post.EF.Repositories;
    using dihiddie.Utils.GoogleBlogpostsLoader.Models;

    using Microsoft.Extensions.DependencyInjection;

    using Newtonsoft.Json;

    public class Program
    {
        private static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection().AddSingleton<IPostRepository, PostRepository>()
                .BuildServiceProvider();

            var postRepo = serviceProvider.GetService<IPostRepository>();

            var path = @"C:\work\personal\dihiddie\dihiddie\Utils\dihiddie.Utils.GoogleBlogpostsLoader\blogposts.json";
            var responseBodyPostsInfo = File.ReadAllText(path);
            var des = JsonConvert.DeserializeObject<BlogPostInfo>(responseBodyPostsInfo);

            foreach (var blogPost in des.Items)
            {
                var content = new PostContent { Content = Encoding.UTF8.GetBytes(blogPost.content), Title = blogPost.title };
                postRepo.SaveContentAsync(content).GetAwaiter().GetResult();

                var info = new PostInformation
                               {
                                   CreateDateTime = blogPost.published,
                                   IsBlogPost = true,
                                   PostContentId = content.Id,
                                   IsDraft = false,
                                   Title = content.Title,
                                   UpdateDateTime = blogPost.updated
                               };
                postRepo.SaveAsync(info);
            }
        }
    }
}