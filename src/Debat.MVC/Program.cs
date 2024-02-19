using Debat.Core.Application.Repositories;
using Debat.Core.Application.Services;
using Debat.Core.Domain.Entities;
using Debat.Persistence.AppDbContext;
using Debat.Business.Services;
using Debat.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ITopicService, TopicService>();
builder.Services.AddScoped<ITopicRepository, TopicRepository>();

builder.Services.AddScoped<ICommunityService, CommunityService>();
builder.Services.AddScoped<ICommunityRepository, CommunityRepository>();

builder.Services.AddScoped<ICommunityMemberService, CommunityMemberService>();
builder.Services.AddScoped<ICommunityMemberRepository, CommunityMemberRepository>();

builder.Services.AddScoped<ICommunityImageService, CommunityImageService>();
builder.Services.AddScoped<ICommunityImageRepository, CommunityImageRepository>();

builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();

builder.Services.AddScoped<IDefaultValueService, DefaultValueService>();
builder.Services.AddScoped<IDefaultValueRepository, DefaultValueRepository>();

builder.Services.AddScoped<IUserImageService, UserImageService>();
builder.Services.AddScoped<IUserImageRepository, UserImageRepository>();

builder.Services.AddScoped<ILevelService, LevelService>();
builder.Services.AddScoped<ILevelRepository, LevelRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<IAnswerService, AnswerService>();
builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();

builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddScoped<IAnswerVoteService, AnswerVoteService>();
builder.Services.AddScoped<IAnswerVoteRepository, AnswerVoteRepository>();

builder.Services.AddScoped<IBookmarkService, BookmarkService>();
builder.Services.AddScoped<IBookmarkRepository, BookmarkRepository>();

builder.Services.AddIdentity<AppUser, IdentityRole>().AddDefaultTokenProviders().AddEntityFrameworkStores<DebatDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    //
});

builder.Services.AddDbContext<DebatDbContext>(options =>
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