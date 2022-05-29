using MesAdmin_Business.Repository;
using MesAdmin_Business.Repository.IRepository;
using MesAdmin_DataAccess.Data.RPMData;
using MesAdmin_DataAccess.Data.SOADB;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<SOADBApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SOADBConnection")));

builder.Services.AddDbContext<RPMDataÀpplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("RPMDataConnection")));

builder.Services.AddScoped<IProcessResourcesRepository, ProcessResourcesRepository>();
builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
builder.Services.AddScoped<IProcessResourcesVMRepository, ProcessResourcesVMRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
