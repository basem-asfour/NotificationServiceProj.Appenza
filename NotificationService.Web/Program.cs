using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NotificationService.BLL.Consumer;
using NotificationService.BLL.Provider;
using NotificationService.Interface;
using NotificationService.Web.Data;
using NotificationService.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IRabbitMQService, RabbitMQService>();
builder.Services.AddScoped<INotificationProvider, NotificationProvider>();
builder.Services.AddScoped<INotificationProvider, SMSProvider>();
builder.Services.AddScoped<INotificationProvider, EmailProvider>();
builder.Services.AddScoped<INotificationProvider, WhatsAppProvider>();
builder.Services.AddHostedService<SmsConsumer>();
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
