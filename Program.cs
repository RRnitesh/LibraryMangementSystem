using Library_ManagementSystem.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//registering applicationdbcontext with connection string
builder.Services.AddDbContext<ApplicationDbcontext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.services.adddbcontext<applicationdbcontext> this will register applicationdbcontext in DIC


//add session services:
//builder.Services.AddDistributedMemoryCache();
//it registers in memeory-cache which is necessary for session storage;
//addession: session services and allow us to configure options 
//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromMinutes(30);
//    //options.Cookie.HttpOnly = true; // helps mitigate xss attack
//    options.Cookie.IsEssential = true; // essentail for app to function correclty
//});


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


//adding session middleware before the authorization middleware
//app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
