using Love.DbContext;
using Love.interfaces;
using Love.Repositories;
using Love.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TrueLoveDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TrueLoveConnection")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<TrueLoveDbContext>();
builder.Services.AddTransient<IMainUserInfo, UserInfoRepository>();
builder.Services.AddTransient<IToken, TokenService>();
builder.Services.ConfigureApplicationCookie(config => {
    config.LoginPath = "/Login";
});

var app = builder.Build();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.UseAuthentication();
app.UseAuthorization();

app.Run();