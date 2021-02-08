namespace dihiddie.Utils.GoogleBlogpostsLoader
{
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    using AutoMapper;

    using dihiddie.DAL.Post.Core.Repositories;
    using dihiddie.DAL.Post.EF.AutomapperProfiles;
    using dihiddie.DAL.Post.EF.Context;
    using dihiddie.DAL.Post.EF.Repositories;
    using dihiddie.Utils.GoogleBlogpostsLoader.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using Newtonsoft.Json;


    public class Program
    {
        private static void Main(string[] args)
        {
            AddInContext().GetAwaiter().GetResult();

            //var serviceProvider = new ServiceCollection().AddSingleton<IPostRepository, PostRepository>()
            //    .AddSingleton<DihiddieContext>().AddAutoMapper(c => c.AddProfile(new PostProfile()))
            //    .BuildServiceProvider();
            //var mappingConfig = new MapperConfiguration(mc =>
            //    {
            //        mc.AddProfile(new PostProfile());
            //    });
            //IMapper mapper = mappingConfig.CreateMapper();

            //var postRepo = new PostRepository(new DihiddieContext(), mapper);

            //// var postRepo = serviceProvider.GetService<IPostRepository>();

            //var path = @"C:\work\personal\dihiddie\dihiddie\Utils\dihiddie.Utils.GoogleBlogpostsLoader\blogposts.json";
            //var responseBodyPostsInfo = File.ReadAllText(path);
            //var des = JsonConvert.DeserializeObject<BlogPostInfo>(responseBodyPostsInfo);

            //foreach (var blogPost in des.Items)
            //{
            //    var content = new DAL.Post.Core.Models.PostContent { Content = Encoding.UTF8.GetBytes(blogPost.content), Title = blogPost.title };
            //    postRepo.SaveContentAsync(content).GetAwaiter().GetResult();


            //    var info = new DAL.Post.Core.Models.PostInformation
            //    {
            //                       CreateDateTime = blogPost.published,
            //                       IsBlogPost = true,
            //                       PostContentId = content.Id,
            //                       IsDraft = false,
            //                       Title = content.Title,
            //                       UpdateDateTime = blogPost.updated
            //                   };
            //    postRepo.SaveAsync(info).GetAwaiter().GetResult();
            //}
        }

        private static async Task AddInContext()
        {
            string connectionString = $@"Server=LOCALHOST\\SQLEXPRESS;Database=dihiddie_test;Trusted_Connection=True;";

            var optionsBuilder = new DbContextOptionsBuilder<DihiddieContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            var context = new DihiddieContext(options);

            var path = @"C:\work\personal\dihiddie\dihiddie\Utils\dihiddie.Utils.GoogleBlogpostsLoader\blogposts.json";
            var responseBodyPostsInfo = File.ReadAllText(path);
            var des = JsonConvert.DeserializeObject<BlogPostInfo>(responseBodyPostsInfo);

            foreach (var blogPost in des.Items)
            {
                var postContent = new PostContent
                                      {
                                          Content = Encoding.UTF8.GetBytes(blogPost.content), Title = blogPost.title
                                      };
                await context.PostContent.AddAsync(postContent).ConfigureAwait(false);
                await context.SaveChangesAsync().ConfigureAwait(false);


                var postInfo = new PostInformation
                                   {
                                       CreateDateTime = blogPost.published,
                                       IsBlogPost = true,
                                       PostId = postContent.Id,
                                       IsDraft = false,
                                       Title = blogPost.title,
                                       UpdateDateTime = blogPost.updated
                                   };
                await context.PostInformation.AddAsync(postInfo).ConfigureAwait(false);
                await context.SaveChangesAsync().ConfigureAwait(false);
            }
        }
    }
}
