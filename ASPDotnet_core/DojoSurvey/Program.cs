var builder = WebApplication.CreateBuilder(args);
// Services should be brought in before the initailization of the build
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Builder code to bring features to the app
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();


// Tells the project to use the controller
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );


// This will always be at the bottom
app.Run();
