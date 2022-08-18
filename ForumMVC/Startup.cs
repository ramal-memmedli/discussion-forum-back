using BusinessLayer.Implementations;
using BusinessLayer.Services;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Data;
using DataAccessLayer.Implementations;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumMVC
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ITopicService, TopicRepository>();
            services.AddScoped<ITopicData, TopicData>();

            services.AddScoped<ICommunityService, CommunityRepository>();
            services.AddScoped<ICommunityData, CommunityData>();

            services.AddScoped<ICommunityMemberService, CommunityMemberRepository>();
            services.AddScoped<ICommunityMemberData, CommunityMemberData>();

            services.AddScoped<ICommunityImageService, CommunityImageRepository>();
            services.AddScoped<ICommunityImageData, CommunityImageData>();

            services.AddScoped<IImageService, ImageRepository>();
            services.AddScoped<IImageData, ImageData>();

            services.AddScoped<IDefaultValueService, DefaultValueRepository>();
            services.AddScoped<IDefaultValueData, DefaultValueData>();

            services.AddScoped<IUserImageService, UserImageRepository>();
            services.AddScoped<IUserImageData, UserImageData>();

            services.AddScoped<ILevelService, LevelRepository>();
            services.AddScoped<ILevelData, LevelData>();

            services.AddScoped<ICategoryService, CategoryRepository>();
            services.AddScoped<ICategoryData, CategoryData>();

            services.AddScoped<IAnswerService, AnswerRepository>();
            services.AddScoped<IAnswerData, AnswerData>();

            services.AddScoped<ICommentService, CommentRepository>();
            services.AddScoped<ICommentData, CommentData>();

            services.AddScoped<IAnswerVoteService, AnswerVoteRepository>();
            services.AddScoped<IAnswerVoteData, AnswerVoteData>();

            services.AddScoped<IBookmarkService, BookmarkRepository>();
            services.AddScoped<IBookmarkData, BookmarkData>();

            services.AddIdentity<AppUser, IdentityRole>().AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                //
            });

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("default"));
            });

            services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/account/login";
            });

            services.AddControllersWithViews();

            services.AddAuthentication();
            services.AddAuthorization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=dashboard}/{action=index}/{id?}"
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=home}/{action=index}/{id?}"
                    );
            });
        }
    }
}
