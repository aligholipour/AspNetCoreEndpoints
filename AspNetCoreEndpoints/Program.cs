using AspNetCoreEndpoints.Exntensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == 404)
    {
        context.Request.Path = "/Home/Error";
        await next();
    }
});

app.UseRouting();

app.UseAuthorization();

app.UseCustomEndpoint("/my-endpoint", message =>
{
    message.Title = "CustomMiddleware With specific title";
    message.ResponseMessage = "Response message from custom endpoint";
});

app.UseCustomEndpoint("/my-endpoint2");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
