using ChatApplication.Application.Settings;
using ChatApplication.Dommain.Interfaces.UserFriend;
using ChatApplication.Infra.Repository.UserFriend;
using ChatApplication.IOC;
using ChatApplication.webApi.Interfaces;
using ChatApplication.webApi.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JWTSettings>(builder.Configuration.GetSection("Jwt"));
builder.Services.Configure<BDSettings>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.Configure<BlobSettings>(builder.Configuration.GetSection("BlobSettings"));

builder.Services.AddScoped<IJWTService, JWTService>();
builder.Services.AddScoped<IHashPassword, HashPassword>();
builder.Services.AddScoped<SignalRServices>();
builder.Services.AddScoped<IUserFriendRepositoryCommands, UserFriendsRepositoryCommands>();

builder.Services.AddScoped<UserFriendsRepositoryQuery>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfra(builder.Configuration);

builder.Services.Authentication(builder.Configuration);

builder.Services.AddInterfaces();

builder.Services.AddInterfacesServices();

builder.Services.AddFluentValidate();

builder.Services.AddMediator();

builder.Services.AddSignalR();

builder.Services.AddSwagger();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();   
app.UseAuthorization();

app.MapControllers();

app.Run();
