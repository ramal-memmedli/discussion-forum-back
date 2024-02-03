using BusinessLayer.Implementations;
using BusinessLayer.Services;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Data;
using DataAccessLayer.Implementations;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ForumMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<ITopicService, TopicRepository>();
            builder.Services.AddScoped<ITopicData, TopicData>();

            builder.Services.AddScoped<ICommunityService, CommunityRepository>();
            builder.Services.AddScoped<ICommunityData, CommunityData>();

            builder.Services.AddScoped<ICommunityMemberService, CommunityMemberRepository>();
            builder.Services.AddScoped<ICommunityMemberData, CommunityMemberData>();

            builder.Services.AddScoped<ICommunityImageService, CommunityImageRepository>();
            builder.Services.AddScoped<ICommunityImageData, CommunityImageData>();

            builder.Services.AddScoped<IImageService, ImageRepository>();
            builder.Services.AddScoped<IImageData, ImageData>();

            builder.Services.AddScoped<IDefaultValueService, DefaultValueRepository>();
            builder.Services.AddScoped<IDefaultValueData, DefaultValueData>();

            builder.Services.AddScoped<IUserImageService, UserImageRepository>();
            builder.Services.AddScoped<IUserImageData, UserImageData>();

            builder.Services.AddScoped<ILevelService, LevelRepository>();
            builder.Services.AddScoped<ILevelData, LevelData>();

            builder.Services.AddScoped<ICategoryService, CategoryRepository>();
            builder.Services.AddScoped<ICategoryData, CategoryData>();

            builder.Services.AddScoped<IAnswerService, AnswerRepository>();
            builder.Services.AddScoped<IAnswerData, AnswerData>();

            builder.Services.AddScoped<ICommentService, CommentRepository>();
            builder.Services.AddScoped<ICommentData, CommentData>();

            builder.Services.AddScoped<IAnswerVoteService, AnswerVoteRepository>();
            builder.Services.AddScoped<IAnswerVoteData, AnswerVoteData>();

            builder.Services.AddScoped<IBookmarkService, BookmarkRepository>();
            builder.Services.AddScoped<IBookmarkData, BookmarkData>();

            builder.Services.AddIdentity<AppUser, IdentityRole>().AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

            builder.Services.Configure<IdentityOptions>(options =>
            {
                //
            });

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("default"));
            });

            builder.Services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/account/login";
            });

            builder.Services.AddControllersWithViews();

            builder.Services.AddAuthentication();
            builder.Services.AddAuthorization();


            WebApplication app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=dashboard}/{action=index}/{id?}"
                );

            app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=home}/{action=index}/{id?}"
                );

            app.Run();
        }
    }
}
