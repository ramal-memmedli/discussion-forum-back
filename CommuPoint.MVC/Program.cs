using CommuPoint.Business.Services;
using CommuPoint.Core.Application.DataAbstracts;
using CommuPoint.Core.Application.Services;
using CommuPoint.Core.Domain.Entities;
using CommuPoint.Persistence.AppDbContext;
using CommuPoint.Persistence.DataConcretes;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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

builder.Services.AddIdentity<AppUser, IdentityRole>().AddDefaultTokenProviders().AddEntityFrameworkStores<CommuPointDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    //
});

builder.Services.AddDbContext<CommuPointDbContext>(options =>
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