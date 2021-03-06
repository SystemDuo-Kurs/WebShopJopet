using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using WebShopJopet.Areas.Identity;
using WebShopJopet.Data;
using WebShopJopet.Services;
using WebShopJopet.Viewmodels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddMudServices();

builder.Services.AddTransient<IUserMan, UserMan>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<IOrderService, OrderService>();

builder.Services.AddTransient<IArticleService, ArticleService>();
builder.Services.AddTransient<IArticleList, ArticleList>();
builder.Services.AddTransient<IArticleEditVM, ArticleEditVM>();

builder.Services.AddTransient<IShopping, Shopping>();

builder.Services.AddTransient<IAddressService, AddressService>();
builder.Services.AddTransient<IAddressEdit, AddressEdit>();
builder.Services.AddTransient<IAddressList, AddressList>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
