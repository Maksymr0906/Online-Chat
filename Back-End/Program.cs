using Microsoft.EntityFrameworkCore;
using OnlineChat.Data;
using OnlineChat.Models.Domain;
using OnlineChat.Repositories.Implementation;
using OnlineChat.Repositories.Interface;
using OnlineChat.Services.Implementation;
using OnlineChat.Services.Interface;
using OnlineChat.Mapping;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddAutoMapper(typeof(MessageProfile));
builder.Services.AddAutoMapper(typeof(ChatProfile));
builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IRepository<Chat>), typeof(ChatRepository));
builder.Services.AddScoped(typeof(IChatService), typeof(ChatService));
builder.Services.AddScoped(typeof(IMessageService), typeof(MessageService));
builder.Services.AddScoped(typeof(IUserService), typeof(UserService));
builder.Services.AddDbContext<ChatDbContext>(options =>
{
    var serverVersion = new MySqlServerVersion(new Version(8, 3, 0));
    options.UseMySql(builder.Configuration.GetConnectionString("OnlineChatConnectionString"), serverVersion);
});
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();