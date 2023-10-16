using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
options =>
{
   
   /* options.LoginPath = "/User/Product/Index";*/
    options.LoginPath = "/Admin/Account/Login";
    options.ReturnUrlParameter = "returnUrl";
}).AddCookie("Admin", options =>
{
    options.LoginPath = new PathString("/Admin/Account/Login");
/*}).AddCookie("User", options =>
{
    options.LoginPath = new PathString("/User/Product/Index");*/

});

builder.Services.AddControllersWithViews();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseStatusCodePagesWithReExecute("/Error/{0}");
    /* app.UseExceptionHandler("/Home/Error");*/
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePages();
// This method gets called by the runtime. Use this method to add services to the container.
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();



/*app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
          name: "areas",
          pattern: "{area=Admin}/{controller=Account}/{action=Index}/{id?}/{*ReturnUrl}"
        );
    });
*/

app.UseEndpoints(endpoints =>
{
  
    /*endpoints.MapAreaControllerRoute(
       name: "user",
   areaName: "User",
       pattern: "User/{controller=Home}/{action=Index}/{id?}");*/
    endpoints.MapAreaControllerRoute(
   name: "admin",
areaName: "Admin",
   pattern: "Admin/{controller=Account}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.Run();
