using HolaMundoMVC.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add db context
var serviceCollection = builder.Services.AddDbContext<EscuelaContext>(
    options => options.UseInMemoryDatabase(databaseName: "testDB")
);

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

var provider = serviceCollection.BuildServiceProvider();

using(var scope = provider.CreateScope())
{
    EscuelaContext context;
    IServiceProvider services = scope.ServiceProvider;

    try
    {
        context = services.GetRequiredService<EscuelaContext>();
        context.Database.EnsureCreated();
    }
    catch (System.Exception ex)
    {
        // Log the error
        // var logger = services.GetRequiredService<ILogger>();
        // logger.LogError(ex, "An error ocurred creating the DB.");
    }
}

// Run app
app.Run();
