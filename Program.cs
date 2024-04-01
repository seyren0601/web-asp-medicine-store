using Medicine_Store.DAL;
using Microsoft.EntityFrameworkCore;
using Medicine_Store.DAL.Entities;
using Medicine_Store.DAL.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")!));
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
}).AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<Service_Thuoc>();
builder.Services.AddScoped<Service_Cart>();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.MapPost("/cart_details/{user_id}", (string user_id, Service_Cart service) =>
{
    return service.GetCartDetails(user_id);
});

app.MapGet("/cart_amount/{user_id}", (string user_id, Service_Cart service) =>
{
    List<Cart_details> details = service.GetCartDetails(user_id);
    if (details != null) return details.Count;
    else return StatusCodes.Status404NotFound;
});

app.MapPost("/add_cart", ([FromBody]AddCartRequest request, Service_Cart service) =>
{
    return service.AddToCart(request.user_id, request.thuoc_id, request.amount);
});

app.MapGet("/get_stock/{thuoc_id}", (string thuoc_id, Service_Thuoc service) =>
{
    return service.GetStock(thuoc_id);
});

app.Run();

record AddCartRequest
{
    public string user_id { get; set; }
    public string thuoc_id { get; set; }
    public int amount { get; set; }
}