using NotificationService.BLL.Consumer;
using NotificationService.BLL.Provider;
using NotificationService.Interface;
using NotificationService.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<EmailProvider>();
builder.Services.AddTransient<SMSProvider>();
builder.Services.AddTransient<WhatsAppProvider>();
builder.Services.AddTransient<NotificationProvider>();
builder.Services.AddSingleton<INotificationProviderFactory, NotificationProviderFactory>();


builder.Services.AddSingleton<IRabbitMQService, RabbitMQService>();
builder.Services.AddHostedService<SmsConsumer>();
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
