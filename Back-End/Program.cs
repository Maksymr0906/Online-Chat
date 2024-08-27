using Microsoft.EntityFrameworkCore;
using OnlineChat.Data;
using OnlineChat.Repositories.Implementation;
using OnlineChat.Repositories.Interface;
using OnlineChat.Services.Implementation;
using OnlineChat.Services.Interface;
using OnlineChat.Mapping;
using OnlineChat.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddAutoMapper(typeof(MessageProfile));
builder.Services.AddAutoMapper(typeof(ChatProfile));

builder.Services.AddScoped(typeof(IChatRepository), typeof(ChatRepository));
builder.Services.AddScoped(typeof(IMessageRepository), typeof(MessageRepository));
builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));

builder.Services.AddScoped(typeof(IChatService), typeof(ChatService));
builder.Services.AddScoped(typeof(IMessageService), typeof(MessageService));
builder.Services.AddScoped(typeof(IUserService), typeof(UserService));

builder.Services.AddDbContext<ChatDbContext>(options =>
{
    var serverVersion = new MySqlServerVersion(new Version(8, 3, 0));
    options.UseMySql(builder.Configuration.GetConnectionString("OnlineChatConnectionString"), serverVersion);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyHeader();
    options.AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<ChatHub>("/chathub");

app.Run();