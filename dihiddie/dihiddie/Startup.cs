using AutoMapper;
using dihiddie.AutoMapperProfiles;
using dihiddie.BAL.DocxReader.UnitOfWork;
using dihiddie.BAL.DocxReader.Xceed.UnitOfWork;
using dihiddie.DAL.Post.Core.UnitOfWorks;
using dihiddie.DAL.Post.EF.AutomapperProfiles;
using dihiddie.DAL.Post.EF.Context;
using dihiddie.DAL.Post.EF.UnitOfWorks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace dihiddie
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            ConfigureMapper(services);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddRazorPagesOptions(options => { options.RootDirectory = "/Pages"; });
            services.AddScoped<IDocxUnitOfWork, DocxUnitOfWork>(SpaApplicationBuilderExtensions =>
                new DocxUnitOfWork(Configuration.GetSection("StoriesFolderPath").Value));
            services.AddScoped<IPostUnitOfWork, PostUnitOfWork>();
            services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();
            services.AddDbContext<DihiddieContext>(o =>
                o.UseSqlServer(Configuration.GetConnectionString(nameof(DihiddieContext))));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => { options.LoginPath = new PathString("/Login"); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DihiddieContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            context.Database.Migrate();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc();
        }

        private void ConfigureMapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PostProfile());
                mc.AddProfile(new EntryProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
