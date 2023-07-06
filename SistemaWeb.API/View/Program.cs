using SistemaWeb.API.Services.Interfaces;
using SistemaWeb.API.Services;
using SistemaWeb.API.Repository.Interfaces;
using SistemaWeb.API.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<IFornecedorService, FornecedorService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:FornecedorAPI"]);
});
//builder.Services.AddScoped<IFornecedorService, FornecedorService>();

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
    pattern: "{controller=Fornecedor}/{action=FornecedorIndex}/{id?}");

app.Run();
