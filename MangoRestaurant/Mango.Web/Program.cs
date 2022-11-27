using Mango.Web;
using Mango.Web.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add HttpClinet
builder.Services.AddHttpClient<IProductService, IProductService>();

// Set Default values
SD.ProductAPIBase = builder.Configuration["ServiceURLs:ProductAPI"];

// Add Dependency Injection
builder.Services.AddScoped<IProductService, IProductService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.Run();
