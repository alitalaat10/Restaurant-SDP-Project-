using design_pattern.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlite"));
});
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
// builder.Services.AddAuthentication("visitor").AddScheme<CookieAuthenticationOptions, AuthHandler>("visitor", (x) => { })
// .AddCookie("local");
// builder.Services.AddAuthorization(p =>
// {
//     p.AddPolicy("user", b =>
//     {
//         b.AddAuthenticationSchemes("local","visitor")
//         .RequireAuthenticatedUser();
//     });
// });

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

app.UseSession();
// app.UseAuthentication();
// app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");


app.Run();