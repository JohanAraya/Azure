//using ComponentesMVC.Services;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddTransient<IMailService, NullMailService>();
// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

}
else
{
    app.UseExceptionHandler("/error");
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(cfg => {
    cfg.MapControllerRoute("Fallback",
    "{controller}/{action}/{id?}",
    new { controller = "App", action = "Login" });
    cfg.MapRazorPages();
});


app.Run();
