using VirtualCompanion.Core.Interfaces;
using VirtualCompanion.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IItemRepository, ItemRepository>(provider =>
    new ItemRepository(connectionString));
builder.Services.AddScoped<IPetRepository, PetRepository>(provider =>
    new PetRepository(connectionString));
builder.Services.AddScoped<IOwnerRepository, OwnerRepository>(provider =>
    new OwnerRepository(connectionString));

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
