using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using SMARTLY.Pages;
using SMARTLY.Pages.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSession();
builder.Services.AddSingleton<Database>();
builder.Services.AddScoped<UserPageModel>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession();


app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
   
});

app.Run();