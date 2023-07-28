using FeedbackApp.Domain;
using FeedbackApp.Infrastructure.Context;
using FeedbackApp.Infrastructure.Repositories;
using FeedbackApp.Infrastructure.Repositories.EntityFramework;
using FeedbackApp.Services.Mapping;
using FeedbackApp.Services.Services.Feedback;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(MapProfile));

builder.Services.AddScoped<IFeedBackService, FeedBackService>();
builder.Services.AddScoped<IFeedBackRepository, EFFeedBackRepository>();


var connectionString = builder.Configuration.GetConnectionString("FeedBack");
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<FeedBackContext>(opt =>
        opt.UseNpgsql(connectionString));

var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

var feedBackContext = services.GetRequiredService<FeedBackContext>();
feedBackContext.Database.EnsureCreated();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

