using VirtualCompanion.Core.Interfaces.Repository;
using VirtualCompanion.Core.Interfaces.Service;
using VirtualCompanion.Core.Services;
using VirtualCompanion.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Repositories
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>(provider => new OwnerRepository(connectionString));
builder.Services.AddScoped<IPetRepository, PetRepository>(provider => new PetRepository(connectionString));
builder.Services.AddScoped<IItemRepository, ItemRepository>(provider => new ItemRepository(connectionString));
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>(provider => new InventoryRepository(connectionString));

// Services
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
